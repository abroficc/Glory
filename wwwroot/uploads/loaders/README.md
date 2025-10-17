# Radio Spinner Loader

This directory contains a customizable loading spinner animation that can be used throughout the application.

## Files

- `radio-spinner.html` - HTML file with the spinner animation
- `radio-spinner.css` - CSS styles for the spinner animation
- `radio-spinner.js` - JavaScript functions to show/hide the spinner
- `demo.html` - Demo page showing how to use the spinner

## Usage

### Including in Layout

The CSS and JS files are automatically included in the main layout file (`_VerticalLayout.cshtml`).

### JavaScript Functions

```javascript
// Show simple loader
showLoader();

// Hide simple loader
hideLoader();

// Show loader with overlay (blocks UI interaction)
showLoaderWithOverlay();

// Hide loader with overlay
hideLoaderWithOverlay();
```

### Direct HTML Usage

You can also include the spinner directly in your HTML:

```html
<div class="loadingio-spinner-radio-2by998twmg8">
  <div class="ldio-yzaezf3dcmj">
    <div></div>
    <div></div>
    <div></div>
  </div>
</div>
```

## Customization

You can customize the colors by modifying the CSS variables in `radio-spinner.css`:

- `.ldio-yzaezf3dcmj div:nth-child(1)` - Inner circle color (#f47e60)
- `.ldio-yzaezf3dcmj div:nth-child(2)` - Middle ring color (#f8b26a)
- `.ldio-yzaezf3dcmj div:nth-child(3)` - Outer ring color (#abbd81)

## Demo

Open `demo.html` in your browser to see the spinner in action.