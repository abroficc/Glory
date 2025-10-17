const {series, src, dest, parallel, watch} = require("gulp");

const autoprefixer = require("autoprefixer");
const postcss = require("gulp-postcss");
const browsersync = require("browser-sync");
const concat = require("gulp-concat");
const CleanCSS = require("gulp-clean-css");
const del = require("del");
const fileinclude = require("gulp-file-include");
const newer = require("gulp-newer");
const rename = require("gulp-rename");
const rtlcss = require("gulp-rtlcss");
const sourcemaps = require("gulp-sourcemaps");
const sass = require("gulp-sass")(require("sass"));
const uglify = require("gulp-uglify");

const pluginFile = require("./plugins.config"); // Import the plugins list

const paths = {
    baseDistAssets: "wwwroot/", // build assets directory
    baseSrcAssets: "wwwroot/",   // source assets directory
};


// Warning not show
process.removeAllListeners('warning');

// Copying Third Party Plugins Assets
const plugins = function () {
    const out = paths.baseDistAssets + "plugins/";

    pluginFile.forEach(({name, vendorsJS, vendorCSS, vendorFonts, assets, fonts, font, media, img, webfonts}) => {

        const handleError = (label, files) => (err) => {
            const shortMsg = err.message.split('\n')[0];
            console.error(`\n${label} - ${shortMsg}`);
            throw new Error(`${label} failed`);
        };

        if (vendorsJS) {
            src(vendorsJS)
                .on('error', handleError('vendorsJS'))
                .pipe(concat("vendors.min.js"))
                .pipe(dest(paths.baseDistAssets + "js/"));
        }

        if (vendorCSS) {
            src(vendorCSS)
                .pipe(concat("vendors.min.css"))
                .on('error', handleError('vendorCSS'))
                .pipe(dest(paths.baseDistAssets + "css/"));
        }

        if (vendorFonts) {
            src(vendorFonts)
                .on('error', handleError('vendorFonts'))
                .pipe(dest(paths.baseDistAssets + "css/fonts/"));
        }

        if (assets) {
            src(assets)
                .on('error', handleError('assets'))
                .pipe(dest(`${out}${name}/`));
        }

        if (img) {
            src(img)
                .on('error', handleError('img'))
                .pipe(dest(`${out}${name}/img/`));
        }

        if (media) {
            src(media)
                .on('error', handleError('media'))
                .pipe(dest(`${out}${name}/`));
        }


        if (fonts) {
            src(fonts)
                .on('error', handleError('fonts'))
                .pipe(dest(`${out}${name}/fonts/`));
        }

        if (font) {
            src(font)
                .on('error', handleError('font'))
                .pipe(dest(`${out}${name}/font/`));
        }

        if (webfonts) {
            src(webfonts)
                .on('error', handleError('webfonts'))
                .pipe(dest(`${out}${name}/webfonts/`));
        }
    });

    return Promise.resolve();
};

// Bundle all custom CSS files into one
const bundleCustomCSS = function () {
    const out = paths.baseDistAssets + "css/";
    
    return src([
        paths.baseDistAssets + "css/app.min.css",
        paths.baseDistAssets + "css/right-sidebar.css",
        paths.baseDistAssets + "css/custom.css",
        paths.baseDistAssets + "css/rtl.css",
        paths.baseDistAssets + "css/basic-settings-modal.css"
    ])
    .pipe(concat("custom-bundle.min.css"))
    .pipe(dest(out));
};

// Bundle all custom JS files into one
const bundleCustomJS = function () {
    const out = paths.baseDistAssets + "js/";
    
    return src([
        paths.baseDistAssets + "js/account-tree.js",
        paths.baseDistAssets + "js/additional-commissions.js",
        paths.baseDistAssets + "js/aden-net.js",
        paths.baseDistAssets + "js/branches.js",
        paths.baseDistAssets + "js/config.js",
        paths.baseDistAssets + "js/filters.js",
        paths.baseDistAssets + "js/header-dropdowns.js",
        paths.baseDistAssets + "js/network-cards.js",
        paths.baseDistAssets + "js/payment-distribution-principle.js",
        paths.baseDistAssets + "js/pricing-groups.js",
        paths.baseDistAssets + "js/pricing-ratios.js",
        paths.baseDistAssets + "js/services.js",
        paths.baseDistAssets + "js/settings.js",
        paths.baseDistAssets + "js/south-spafone-packages.js",
        paths.baseDistAssets + "js/south-spafone.js",
        paths.baseDistAssets + "js/system-connections.js",
        paths.baseDistAssets + "js/ui-polish.js",
        paths.baseDistAssets + "js/voucher-modal.js",
        paths.baseDistAssets + "js/wifi-packages.js",
        paths.baseDistAssets + "js/yemen-forge-packages.js"
    ])
    .pipe(concat("custom-bundle.min.js"))
    .pipe(uglify())
    .pipe(dest(out));
};

const scss = function () {
    const out = paths.baseDistAssets + "css/";

    return src(paths.baseSrcAssets + "scss/**/*.scss")
        .pipe(sourcemaps.init())
        .pipe(sass.sync().on('error', sass.logError)) // scss to css
        .pipe(postcss([autoprefixer({ overrideBrowserslist: ["last 2 versions"] })]))
        .pipe(dest(out))
        .pipe(CleanCSS())
        .pipe(rename({suffix: ".min"}))
        .pipe(sourcemaps.write("./")) // source maps
        .pipe(dest(out));
};

const rtl = function () {
    const out = paths.baseDistAssets + "css/";

    return src(paths.baseSrcAssets + "scss/**/*.scss")
        .pipe(sourcemaps.init())
        .pipe(sass.sync().on('error', sass.logError)) // scss to css
        .pipe(postcss([autoprefixer({ overrideBrowserslist: ["last 2 versions"] })]))
        .pipe(rtlcss())
        .pipe(rename({suffix: "-rtl"}))
        .pipe(dest(out))
        .pipe(CleanCSS())
        .pipe(rename({suffix: ".min"}))
        .pipe(sourcemaps.write("./")) // source maps
        .pipe(dest(out));
}

function watchFiles() {
    watch(paths.baseSrcAssets + "scss/**/*.scss", series(scss));
}

// Production Tasks
exports.default = series(
    // clean,
    plugins,
    parallel(scss),
    parallel(bundleCustomCSS, bundleCustomJS),
    parallel(watchFiles)
);

// Build Tasks
exports.build = series(
    plugins,
    parallel(scss),
    parallel(bundleCustomCSS, bundleCustomJS)
);

// RTL Tasks
exports.rtl = series(
    plugins,
    parallel(rtl),
    parallel(bundleCustomCSS, bundleCustomJS),
    parallel(watchFiles)
);

// RTL Build Tasks
exports.rtlBuild = series(
    plugins,
    parallel(rtl),
    parallel(bundleCustomCSS, bundleCustomJS)
);