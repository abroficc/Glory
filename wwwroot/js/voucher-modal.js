// Voucher Modal JavaScript functions

// Function to initialize voucher modals
function initializeVoucherModals() {
    // Initialize bootstrap select if available
    if ($('.selectpicker').length > 0) {
        $('.selectpicker').selectpicker();
    }
    
    // Handle modal close buttons for Bootstrap modals
    $(document).on('click', '.modal .btn-close', function() {
        const modalElement = $(this).closest('.modal')[0];
        if (modalElement) {
            const modal = bootstrap.Modal.getInstance(modalElement);
            if (modal) {
                modal.hide();
            } else {
                // If modal instance doesn't exist, create new one and hide
                new bootstrap.Modal(modalElement).hide();
            }
        }
    });
    
    // Handle modal backdrop click to close for Bootstrap modals
    $(document).on('click', '.modal.fade', function(e) {
        if (e.target === this) {
            const modal = bootstrap.Modal.getInstance(this);
            if (modal) {
                modal.hide();
            } else {
                // If modal instance doesn't exist, create new one and hide
                new bootstrap.Modal(this).hide();
            }
        }
    });
    
    // Initialize selectpickers in modals when they are shown
    $(document).on('shown.bs.modal', '.modal', function () {
        $('.selectpicker', this).selectpicker('render');
    });
}

// Function to show a specific modal
function showVoucherModal(modalId) {
    const modalElement = document.querySelector(modalId);
    if (modalElement) {
        // Check if it's a Bootstrap modal
        if (modalElement.classList.contains('fade')) {
            // Bootstrap modal - use proper API
            const modal = new bootstrap.Modal(modalElement);
            modal.show();
            
            // Initialize selectpickers within the modal
            $(modalId).find('.selectpicker').selectpicker('render');
        } else {
            // Custom modal
            $(modalElement).show();
        }
    }
}

// Function to hide a specific modal
function hideVoucherModal(modalId) {
    const modalElement = document.querySelector(modalId);
    if (modalElement) {
        // Check if it's a Bootstrap modal
        if (modalElement.classList.contains('fade')) {
            // Bootstrap modal - use proper API
            const modal = bootstrap.Modal.getInstance(modalElement);
            if (modal) {
                modal.hide();
            } else {
                // If modal instance doesn't exist, create new one and hide
                new bootstrap.Modal(modalElement).hide();
            }
        } else {
            // Custom modal
            $(modalElement).hide();
        }
    }
}

// Initialize components when DOM is ready
document.addEventListener('DOMContentLoaded', function() {
    // Make sure Bootstrap is available
    if (typeof bootstrap !== 'undefined') {
        initializeVoucherModals();
    }
});

// Also initialize when jQuery is ready
$(document).ready(function() {
    // Make sure Bootstrap is available
    if (typeof bootstrap !== 'undefined') {
        initializeVoucherModals();
    }
});