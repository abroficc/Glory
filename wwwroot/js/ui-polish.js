// UI Polish JavaScript functions

// Function to show/hide detailed package options
function slminfo(elementId) {
    var element = $(elementId);
    if (element.is(':visible')) {
        element.hide();
    } else {
        element.show();
    }
}

// Safe DataTables initialization utility
function initDataTable(selector, options = {}) {
    // Set default options
    const defaultOptions = {
        responsive: true,
        destroy: true,
        ...options
    };
    
    // If selector is a string, initialize all matching elements
    if (typeof selector === 'string') {
        $(selector).each(function() {
            const $this = $(this);
            // Check if DataTable is already initialized
            if ($.fn.DataTable.isDataTable(this)) {
                // Destroy existing instance
                $this.DataTable().clear().destroy();
            }
            // Initialize with options
            $this.DataTable(defaultOptions);
        });
    }
    // If selector is a jQuery object
    else if (selector instanceof jQuery) {
        selector.each(function() {
            const $this = $(this);
            // Check if DataTable is already initialized
            if ($.fn.DataTable.isDataTable(this)) {
                // Destroy existing instance
                $this.DataTable().clear().destroy();
            }
            // Initialize with options
            $this.DataTable(defaultOptions);
        });
    }
}

// Initialize components when DOM is ready
document.addEventListener('DOMContentLoaded', function() {
    // Initialize bootstrap select if available
    if ($('.selectpicker').length > 0) {
        $('.selectpicker').selectpicker();
    }
    
    // Safe initialization for all dataTables
    $('table.dataTable').each(function() {
        if (!$.fn.DataTable.isDataTable(this)) {
            $(this).DataTable({
                responsive: true,
                destroy: true
            });
        }
    });
});