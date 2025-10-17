// Radio Spinner Loader Functions

// Show the loading spinner
function showLoader() {
  // Create the loader element if it doesn't exist
  let loader = document.getElementById('radio-loader');
  if (!loader) {
    loader = document.createElement('div');
    loader.id = 'radio-loader';
    loader.className = 'loadingio-spinner-radio-2by998twmg8';
    loader.innerHTML = `
      <div class="ldio-yzaezf3dcmj">
        <div></div>
        <div></div>
        <div></div>
      </div>
    `;
    document.body.appendChild(loader);
  }
  
  // Show the loader
  loader.style.display = 'block';
}

// Hide the loading spinner
function hideLoader() {
  const loader = document.getElementById('radio-loader');
  if (loader) {
    loader.style.display = 'none';
  }
}

// Show loader with overlay (blocks UI interaction)
function showLoaderWithOverlay() {
  // Create overlay if it doesn't exist
  let overlay = document.getElementById('loader-overlay');
  if (!overlay) {
    overlay = document.createElement('div');
    overlay.id = 'loader-overlay';
    overlay.style.cssText = `
      position: fixed;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      background: rgba(0, 0, 0, 0.5);
      z-index: 9999;
      display: flex;
      justify-content: center;
      align-items: center;
    `;
    document.body.appendChild(overlay);
  }
  
  // Create loader if it doesn't exist
  let loader = document.getElementById('radio-loader-overlay');
  if (!loader) {
    loader = document.createElement('div');
    loader.id = 'radio-loader-overlay';
    loader.className = 'loadingio-spinner-radio-2by998twmg8';
    loader.innerHTML = `
      <div class="ldio-yzaezf3dcmj">
        <div></div>
        <div></div>
        <div></div>
      </div>
    `;
    overlay.appendChild(loader);
  }
  
  // Show the overlay
  overlay.style.display = 'flex';
}

// Hide loader with overlay
function hideLoaderWithOverlay() {
  const overlay = document.getElementById('loader-overlay');
  if (overlay) {
    overlay.style.display = 'none';
  }
}

// Initialize the loader CSS
function initLoader() {
  // Check if CSS is already loaded
  const existingLink = document.querySelector('link[href*="radio-spinner.css"]');
  if (!existingLink) {
    const link = document.createElement('link');
    link.rel = 'stylesheet';
    link.type = 'text/css';
    link.href = '/uploads/loaders/radio-spinner.css';
    document.head.appendChild(link);
  }
}

// Initialize when DOM is loaded
if (document.readyState === 'loading') {
  document.addEventListener('DOMContentLoaded', initLoader);
} else {
  initLoader();
}