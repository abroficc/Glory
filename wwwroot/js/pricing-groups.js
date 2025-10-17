$(document).ready(function () {
    // Initialize DataTable with basic configuration
    var pricingGroupsTable = $('#categoriesTable').DataTable();
    
    // Handle form submissions with AJAX
    $('#addCategoryForm, #editCategoryForm').on('submit', function (e) {
        e.preventDefault();
        
        const form = $(this);
        const formId = form.attr('id');
        const prefix = formId === 'addCategoryForm' ? 'add' : 'edit';
        
        // Get form data
        const formData = getFormData(prefix);
        
        // Validate form
        if (!validateForm(formData, prefix)) {
            return;
        }
        
        // Submit form via AJAX
        submitFormViaAjax(formData, prefix);
    });
    
    // Handle global percentage application
    $(document).on('click', '[id$="GlobalPercentage"]', function () {
        const buttonId = $(this).attr('id');
        const prefix = buttonId.replace('GlobalPercentage', '').toLowerCase();
        
        const globalPercentage = $(`#${prefix}-global-percentage`).val();
        
        if (!globalPercentage || globalPercentage < 0 || globalPercentage > 2) {
            alert('الرجاء إدخال نسبة صحيحة بين 0 و 2');
            return;
        }
        
        // Apply the percentage to all fields
        applyGlobalPercentage(globalPercentage, prefix);
    });
    
    // Handle edit from view button
    $('#editFromViewBtn').on('click', function () {
        // Close view modal
        var viewModal = bootstrap.Modal.getInstance(document.getElementById('viewCategoryModal'));
        if (viewModal) {
            viewModal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('viewCategoryModal')).hide();
        }
        
        // Open edit modal (in a real app, you would populate it with data first)
        var editModal = new bootstrap.Modal(document.getElementById('editCategoryModal'));
        editModal.show();
    });
    
    // Handle action buttons in the table
    $('#categoriesTable').on('click', '[data-action]', function () {
        const action = $(this).data('action');
        const row = $(this).closest('tr');
        
        switch (action) {
            case 'view':
                viewCategory(row);
                break;
            case 'edit':
                editCategory(row);
                break;
        }
    });
    
    // Function to get form data
    function getFormData(prefix) {
        const data = {
            groupName: $(`#${prefix}-group-name`).val(),
            groupType: $(`#${prefix}-group-type`).val(),
            sendNotification: $(`#${prefix}-send-notification`).is(':checked')
        };
        
        // Get all service values
        $(`#${prefix}CategoryTabContent input[type="number"]`).each(function () {
            const id = $(this).attr('id');
            const fieldName = id.replace(`${prefix}-`, '');
            data[fieldName] = $(this).val();
        });
        
        return data;
    }
    
    // Function to validate form
    function validateForm(data, prefix) {
        let isValid = true;
        
        // Clear previous validation states
        $(`#${prefix}CategoryTabContent .is-invalid`).removeClass('is-invalid');
        $(`#${prefix}CategoryTabContent .invalid-feedback`).remove();
        
        // Validate required fields
        if (!data.groupName) {
            $(`#${prefix}-group-name`).addClass('is-invalid');
            $(`#${prefix}-group-name`).after('<div class="invalid-feedback">الرجاء إدخال اسم المجموعة</div>');
            isValid = false;
        }
        
        if (!data.groupType) {
            $(`#${prefix}-group-type`).addClass('is-invalid');
            $(`#${prefix}-group-type`).after('<div class="invalid-feedback">الرجاء اختيار نوع المجموعة</div>');
            isValid = false;
        }
        
        // Validate numeric fields (between 0 and 2)
        for (const [key, value] of Object.entries(data)) {
            if (key !== 'groupName' && key !== 'groupType' && key !== 'sendNotification') {
                if (value && (value < 0 || value > 2)) {
                    const fieldId = `${prefix}-${key}`;
                    $(`#${fieldId}`).addClass('is-invalid');
                    $(`#${fieldId}`).after('<div class="invalid-feedback">الرجاء إدخال قيمة بين 0 و 2</div>');
                    isValid = false;
                }
            }
        }
        
        return isValid;
    }
    
    // Function to submit form via AJAX
    function submitFormViaAjax(data, prefix) {
        // Show loading indicator
        const submitBtn = $(`#${prefix}CategoryForm button[type="submit"]`);
        const originalText = submitBtn.html();
        submitBtn.html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> جاري الحفظ...');
        submitBtn.prop('disabled', true);
        
        // In a real application, you would send the data to the server
        // For now, we'll simulate an AJAX call
        setTimeout(function () {
            // Reset button
            submitBtn.html(originalText);
            submitBtn.prop('disabled', false);
            
            // Close modal
            var modal = bootstrap.Modal.getInstance(document.getElementById(`${prefix}CategoryModal`));
            if (modal) {
                modal.hide();
            } else {
                new bootstrap.Modal(document.getElementById(`${prefix}CategoryModal`)).hide();
            }
            
            // Show success message
            alert('تم حفظ البيانات بنجاح');
            
            // Since we're using client-side processing, we need to reload the page
            // to show the new data, or manually add the row to the table
            // For now, we'll just reload the page
            location.reload();
        }, 1500);
    }
    
    // Function to apply global percentage
    function applyGlobalPercentage(percentage, prefix) {
        $(`#${prefix}CategoryTabContent input[type="number"]`).each(function () {
            if ($(this).val() !== '') {
                $(this).val(percentage);
            }
        });
        
        alert(`تم تطبيق النسبة ${percentage} على جميع الحقول`);
    }
    
    // Function to view category
    function viewCategory(row) {
        // In a real application, you would fetch the data from the server
        // For now, we'll just show the modal
        var modal = new bootstrap.Modal(document.getElementById('viewCategoryModal'));
        modal.show();
    }
    
    // Function to edit category
    function editCategory(row) {
        // In a real application, you would populate the form with data from the server
        // For now, we'll just show the modal
        var modal = new bootstrap.Modal(document.getElementById('editCategoryModal'));
        modal.show();
    }
    
    // Initialize tooltips
    $('[data-bs-toggle="tooltip"]').tooltip();
    
    // Handle select all columns button
    $('#selectAllColumns').on('click', function () {
        const allChecked = $('#selectAllCheckbox').prop('checked');
        $('.row-checkbox').prop('checked', !allChecked);
        $('#selectAllCheckbox').prop('checked', !allChecked);
    });
    
    // Handle select all checkbox
    $('#selectAllCheckbox').on('change', function () {
        const isChecked = $(this).prop('checked');
        $('.row-checkbox').prop('checked', isChecked);
    });
    
    // Handle print button
    $('#printButton').on('click', function () {
        window.print();
    });
    
    // Handle export to Excel button
    $('#exportExcelButton').on('click', function () {
        alert('تصدير إلى Excel');
        // In a real application, you would implement Excel export functionality here
    });
});