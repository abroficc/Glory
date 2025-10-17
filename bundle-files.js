const fs = require('fs');
const path = require('path');

// Function to concatenate files
function concatenateFiles(filePaths, outputFile) {
    let output = '';
    
    filePaths.forEach(filePath => {
        if (fs.existsSync(filePath)) {
            console.log(`Adding ${filePath}`);
            output += fs.readFileSync(filePath, 'utf8') + '\n';
        } else {
            console.log(`File not found: ${filePath}`);
        }
    });
    
    fs.writeFileSync(outputFile, output);
    console.log(`Created bundle: ${outputFile}`);
}

// CSS files to bundle
const cssFiles = [
    'wwwroot/css/app.min.css',
    'wwwroot/css/right-sidebar.css',
    'wwwroot/css/custom.css',
    'wwwroot/css/rtl.css',
    'wwwroot/css/basic-settings-modal.css',
    'wwwroot/css/rtl-fixes.css'
];

// JavaScript files to bundle
const jsFiles = [
    'wwwroot/js/account-tree.js',
    'wwwroot/js/additional-commissions.js',
    'wwwroot/js/aden-net.js',
    'wwwroot/js/branches.js',
    'wwwroot/js/config.js',
    'wwwroot/js/filters.js',
    'wwwroot/js/header-dropdowns.js',
    'wwwroot/js/network-cards.js',
    'wwwroot/js/payment-distribution-principle.js',
    'wwwroot/js/pricing-groups.js',
    'wwwroot/js/pricing-ratios.js',
    'wwwroot/js/services.js',
    'wwwroot/js/settings.js',
    'wwwroot/js/south-spafone-packages.js',
    'wwwroot/js/south-spafone.js',
    'wwwroot/js/system-connections.js',
    'wwwroot/js/ui-polish.js',
    'wwwroot/js/voucher-modal.js',
    'wwwroot/js/wifi-packages.js',
    'wwwroot/js/yemen-forge-packages.js'
];

console.log('Creating CSS bundle...');
concatenateFiles(cssFiles.map(f => path.join(__dirname, f)), path.join(__dirname, 'wwwroot/css/custom-bundle.min.css'));

console.log('Creating JavaScript bundle...');
concatenateFiles(jsFiles.map(f => path.join(__dirname, f)), path.join(__dirname, 'wwwroot/js/custom-bundle.min.js'));

console.log('Bundling complete!');