// Payment Distribution Principle Page JavaScript

$(document).ready(function() {
    // Initialize any page-specific functionality here
    console.log('Payment Distribution Principle page loaded');
    
    // Handle modal events
    $('#addPackageModal').on('shown.bs.modal', function () {
        // Focus on first input when modal is shown
        $(this).find('input:first').focus();
    });
    
    $('#editPackageModal').on('shown.bs.modal', function () {
        // Focus on first input when modal is shown
        $(this).find('input:first').focus();
    });
    
    // Handle modal close events
    $('.modal').on('hidden.bs.modal', function () {
        // Reset form validation classes when modal is closed
        $(this).find('.is-invalid').removeClass('is-invalid');
        $(this).find('.is-valid').removeClass('is-valid');
    });
    
    // Handle form input validation on blur
    $('#addPackageForm input[required], #editPackageForm input[required]').on('blur', function() {
        if ($(this).val().trim() === '') {
            $(this).addClass('is-invalid');
        } else {
            $(this).removeClass('is-invalid').addClass('is-valid');
        }
    });
    
    // Handle form input validation on keyup
    $('#addPackageForm input[required], #editPackageForm input[required]').on('keyup', function() {
        if ($(this).val().trim() !== '') {
            $(this).removeClass('is-invalid').addClass('is-valid');
        }
    });
});