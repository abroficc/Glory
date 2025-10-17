/**
 * Header Dropdowns Initialization
 * Fixes issues with notification and message dropdowns not working
 */

// Initialize header dropdowns when DOM is loaded
document.addEventListener('DOMContentLoaded', function() {
    // Use a small delay to ensure all elements are loaded
    setTimeout(initHeaderDropdowns, 100);
});

// Also initialize when the page is loaded (fallback)
window.addEventListener('load', function() {
    initHeaderDropdowns();
});

function initHeaderDropdowns() {
    try {
        // Handle notification dropdown (first .topbar-item with .dropdown-toggle)
        const topbarItems = document.querySelectorAll('.topbar-item');
        if (topbarItems.length > 0) {
            const notificationDropdown = topbarItems[0].querySelector('.dropdown-toggle');
            if (notificationDropdown) {
                initializeDropdown(notificationDropdown);
            }
        }
        
        // Handle message dropdown (second .topbar-item with .dropdown-toggle)
        if (topbarItems.length > 1) {
            const messageDropdown = topbarItems[1].querySelector('.dropdown-toggle');
            if (messageDropdown) {
                initializeDropdown(messageDropdown);
            }
        }
        
        // Handle user profile dropdown (.nav-user .dropdown-toggle)
        const userProfileToggle = document.querySelector('.nav-user .dropdown-toggle');
        if (userProfileToggle) {
            initializeDropdown(userProfileToggle);
        }
    } catch (error) {
        console.error('Error initializing header dropdowns:', error);
    }
}

function initializeDropdown(toggleElement) {
    try {
        // Remove any existing Bootstrap dropdown instance
        const existingInstance = bootstrap.Dropdown.getInstance(toggleElement);
        if (existingInstance) {
            existingInstance.dispose();
        }
        
        // Add click event listener
        // Remove any existing listeners first
        toggleElement.removeEventListener('click', handleDropdownClick);
        toggleElement.addEventListener('click', handleDropdownClick);
        
        // Also ensure Bootstrap dropdown is initialized
        if (!bootstrap.Dropdown.getInstance(toggleElement)) {
            new bootstrap.Dropdown(toggleElement);
        }
    } catch (error) {
        console.error('Error initializing dropdown:', error);
    }
}

function handleDropdownClick(e) {
    e.preventDefault();
    e.stopPropagation();
    
    try {
        // Get or create dropdown instance
        let dropdownInstance = bootstrap.Dropdown.getInstance(this);
        if (!dropdownInstance) {
            dropdownInstance = new bootstrap.Dropdown(this);
        }
        dropdownInstance.toggle();
    } catch (error) {
        console.error('Error toggling dropdown:', error);
    }
}