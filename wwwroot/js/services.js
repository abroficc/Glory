$(function () {
    // Variable to track the currently selected row
    let selectedRow = null;
    
    // Initialize DataTable
    const dt = $("#categoriesTable").DataTable({
        paging: true,
        lengthChange: false,
        searching: false,
        ordering: true,
        info: true,
        autoWidth: false,
        responsive: true,
        // Define columns to match the new table structure
        columnDefs: [
            { targets: 0, width: "40px", className: "text-center" }, // Checkbox column
            { targets: 1, width: "auto" }, // ID column
            { targets: 2, width: "auto" }, // Service name column
            { targets: 3, width: "auto" }, // Default price column
            { targets: 4, width: "100px", className: "text-center" } // Actions column
        ],
        // Add buttons extension
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'print',
                text: 'طباعه',
                className: 'btn btn-outline-secondary btn-sm',
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'colvis',
                text: 'تحديد الحقول',
                className: 'btn btn-outline-secondary btn-sm',
                collectionLayout: 'fixed two-column'
            },
            {
                extend: 'excelHtml5',
                text: 'تصدير اكسل',
                className: 'btn btn-outline-secondary btn-sm',
                exportOptions: {
                    columns: ':visible'
                }
            }
        ],
        language: {
            emptyTable: "لا توجد بيانات",
            info: "إظهار _START_ إلى _END_ من _TOTAL_ سجل",
            infoEmpty: "إظهار 0 إلى 0 من 0",
            paginate: { first:"الأولى", last:"الأخيرة", next:"التالي", previous:"السابق" },
            buttons: {
                colvis: 'تحديد الحقول',
                print: 'طباعه',
                excel: 'تصدير اكسل'
            }
        }
    });
    
    // Move buttons to filter section
    dt.buttons().container().appendTo('#datatables-buttons-container');
    
    // Hide the default buttons container since we're using custom buttons
    $('.dt-buttons').hide();
    
    // Reinitialize buttons when filter section is shown
    $('#toggleFilters').on('click', function() {
        setTimeout(function() {
            // Refresh button styles when filter section is toggled
            $('.dt-buttons .btn').addClass('btn-sm');
        }, 100);
    });
    
    // Ensure buttons are properly styled after initialization
    setTimeout(function() {
        $('.dt-buttons .btn').addClass('btn-sm');
    }, 500);
    
    // Handle filter toggle button
    $('#toggleFilters').on('click', function() {
        var filterSection = $('#filterSection');
        var icon = $(this).find('i');
        var textSpan = $('#toggleFiltersText');
        
        if (filterSection.is(':visible')) {
            // Hide the filter section
            filterSection.hide();
            icon.removeClass('ti-filter-off').addClass('ti-filter');
            textSpan.text('إظهار الفلترة');
        } else {
            // Show the filter section
            filterSection.show();
            icon.removeClass('ti-filter').addClass('ti-filter-off');
            textSpan.text('إخفاء الفلترة');
        }
    });
    
    // Initialize bootstrap-select for category selection with enhanced options
    function initializeSelectPicker() {
        $('.selectpicker').selectpicker({
            style: 'btn-light',
            liveSearch: true,
            liveSearchPlaceholder: 'ابحث...',
            noneSelectedText: 'لم يتم تحديد أي شيء',
            noneResultsText: 'لا توجد نتائج لـ {0}',
            selectAllText: 'تحديد الكل',
            deselectAllText: 'إلغاء تحديد الكل',
            dropupAuto: false,   // منع السلوك التلقائي
            width: '100%',
            container: 'body'    // إخراج القائمة خارج أي كارد/مودال
        });
    }
    
    // Initialize selectpickers when document is ready
    initializeSelectPicker();
    
    // Re-initialize bootstrap-select when modals are shown or hidden
    $('.modal').on('shown.bs.modal hidden.bs.modal', function () {
        $('.selectpicker').selectpicker('refresh');
    });

    // Handle reset filters button
    $('#resetFilters').on('click', function() {
        // Reset all filter input fields
        $('#filter-id').val('');
        $('#filter-service-name').val('');
        $('#filter-default-price').val('');
        $('#filter-year').selectpicker('val', '');
        $('#filter-records').selectpicker('val', '');
        $('.selectpicker').selectpicker('refresh');
        alert('تم إعادة تعيين الفلاتر');
    });
    
    // Handle row selection
    $('#categoriesTable tbody').on('click', 'tr', function(e) {
        // Prevent row selection when clicking on action buttons or dropdowns
        if ($(e.target).closest('.dropdown-toggle, .dropdown-menu, .btn').length) {
            return;
        }
        
        // Toggle selection
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
            selectedRow = null;
        } else {
            // Remove selection from other rows
            $('#categoriesTable tbody tr.selected').removeClass('selected');
            $(this).addClass('selected');
            selectedRow = $(this);
        }
        
        // Enable/disable top action buttons based on selection
        if (selectedRow) {
            $('#topEditButton, #topViewButton').removeClass('disabled');
        } else {
            $('#topEditButton, #topViewButton').addClass('disabled');
        }
    });
    
    // Handle select all checkbox
    $('#selectAll').on('change', function() {
        const isChecked = $(this).is(':checked');
        $('.category-checkbox').prop('checked', isChecked);
        
        // If all rows are selected, enable top action buttons
        if (isChecked) {
            $('#topEditButton, #topViewButton').removeClass('disabled');
        } else {
            $('#topEditButton, #topViewButton').addClass('disabled');
            selectedRow = null;
        }
    });
    
    // Handle individual checkbox selection
    $('#categoriesTable tbody').on('change', '.category-checkbox', function() {
        // If any checkbox is checked, enable top action buttons
        if ($('.category-checkbox:checked').length > 0) {
            $('#topEditButton, #topViewButton').removeClass('disabled');
        } else {
            $('#topEditButton, #topViewButton').addClass('disabled');
            selectedRow = null;
        }
    });
    
    // Handle top action buttons
    $('#topEditButton').on('click', function(e) {
        e.preventDefault();
        if (selectedRow) {
            editPackage(selectedRow);
        } else {
            alert('الرجاء تحديد صف أولاً');
        }
    });
    
    $('#topViewButton').on('click', function(e) {
        e.preventDefault();
        if (selectedRow) {
            viewPackage(selectedRow);
        } else {
            alert('الرجاء تحديد صف أولاً');
        }
    });
    
    // Handle action buttons in the table
    $('#categoriesTable').on('click', '[data-action]', function (e) {
        e.preventDefault(); // Prevent default action
        const action = $(this).data('action');
        const row = $(this).closest('tr');
        
        switch (action) {
            case 'view':
                viewPackage(row);
                break;
            case 'edit':
                editPackage(row);
                break;
        }
    });
    
    // Function to view package
    function viewPackage(row) {
        // In a real application, you would fetch the data from the server
        // For now, we'll just show the modal with placeholder content
        console.log('Showing view modal');
        
        // Set the service details content (assuming it's stored in a variable or fetched from server)
        // For demonstration, we'll use a placeholder
        const serviceDetailsContent = "تفاصيل الخدمة سيتم عرضها هنا";
        $('#view-service-details').html(serviceDetailsContent);
        
        $('#viewServiceModal').modal('show');
    }
    
    // Function to edit package
    function editPackage(row) {
        // In a real application, you would populate the form with data from the server
        // For now, we'll just show the modal with placeholder content
        console.log('Showing edit modal');
        
        // If CKEditor is initialized, set its content
        if (typeof editServiceEditor !== 'undefined' && editServiceEditor) {
            // Set placeholder content for demonstration
            const serviceDetailsContent = "تفاصيل الخدمة الموجودة مسبقاً";
            editServiceEditor.setData(serviceDetailsContent);
        }
        
        $('#editServiceModal').modal('show');
    }
    
    // Handle form submissions with AJAX
    $('#addServiceForm, #editServiceForm').on('submit', function (e) {
        e.preventDefault();
        
        const form = $(this);
        const formId = form.attr('id');
        const prefix = formId === 'addServiceForm' ? 'add' : 'edit';
        
        // Get form data
        const formData = getFormData(prefix);
        
        // Validate form
        if (!validateForm(formData, prefix)) {
            return;
        }
        
        // Submit form via AJAX
        submitFormViaAjax(formData, prefix);
    });
    
    // Handle save button click in modal footer
    $('#addServiceModal .modal-footer .btn-primary, #editServiceModal .modal-footer .btn-primary').on('click', function () {
        const modal = $(this).closest('.modal');
        const form = modal.find('form');
        const formId = form.attr('id');
        const prefix = formId === 'addServiceForm' ? 'add' : 'edit';
        
        // Get form data
        const formData = getFormData(prefix);
        
        // Validate form
        if (!validateForm(formData, prefix)) {
            return;
        }
        
        // Submit form via AJAX
        submitFormViaAjax(formData, prefix);
    });
    
    // Function to get form data
    function getFormData(prefix) {
        // Get the editor content if CKEditor is initialized
        let serviceDetailsContent = $(`#${prefix}-service-details`).val();
        if (prefix === 'add' && typeof addServiceEditor !== 'undefined' && addServiceEditor) {
            serviceDetailsContent = addServiceEditor.getData();
        } else if (prefix === 'edit' && typeof editServiceEditor !== 'undefined' && editServiceEditor) {
            serviceDetailsContent = editServiceEditor.getData();
        }

        const data = {
            serviceName: $(`#${prefix}-service-name`).val(),
            defaultPrice: $(`#${prefix}-default-price`).val(),
            serviceCurrency: $(`#${prefix}-service-currency`).val(),
            dollarPrice: $(`#${prefix}-dollar-price`).val(),
            sarPrice: $(`#${prefix}-sar-price`).val(),
            employeePrice: $(`#${prefix}-employee-price`).val(),
            submitButtonName: $(`#${prefix}-submit-button-name`).val(),
            uniqueLinkNumber: $(`#${prefix}-unique-link-number`).val(),
            linkNumber: $(`#${prefix}-link-number`).val(),
            linkAmount: $(`#${prefix}-link-amount`).val(),
            networkNumber: $(`#${prefix}-network-number`).val(),
            games: $(`#${prefix}-games`).val(),
            cards: $(`#${prefix}-cards`).val(),
            videoApps: $(`#${prefix}-videoapps`).val(),
            sections: $(`#${prefix}-sections`).val(),
            amountCalculation: $(`#${prefix}-amount-calculation`).val(),
            commissionCalculation: $(`#${prefix}-commission-calculation`).val(),
            extraAmountSim: $(`#${prefix}-extra-amount-sim`).val(),
            extraAmountProgramming: $(`#${prefix}-extra-amount-programming`).val(),
            extraAmountGeneral: $(`#${prefix}-extra-amount-general`).val(),
            serviceDetails: serviceDetailsContent,
            showImage: $(`#${prefix}-show-image`).is(':checked'),
            showIcon: $(`#${prefix}-show-icon`).is(':checked'),
            iconColor: $(`#${prefix}-icon-color`).val(),
            iconBgColor: $(`#${prefix}-icon-bg-color`).val(),
            textColor: $(`#${prefix}-text-color`).val(),
            textBgColor: $(`#${prefix}-text-bg-color`).val()
        };
        
        return data;
    }
    
    // Function to validate form
    function validateForm(data, prefix) {
        let isValid = true;
        
        // Clear previous validation states
        $('.is-invalid').removeClass('is-invalid');
        $('.invalid-feedback').remove();
        
        // Validate required fields
        if (!data.serviceName) {
            $(`#${prefix}-service-name`).addClass('is-invalid');
            $(`#${prefix}-service-name`).after('<div class="invalid-feedback">الرجاء إدخال اسم الخدمة</div>');
            isValid = false;
        }
        
        if (!data.defaultPrice) {
            $(`#${prefix}-default-price`).addClass('is-invalid');
            $(`#${prefix}-default-price`).after('<div class="invalid-feedback">الرجاء إدخال السعر الافتراضي</div>');
            isValid = false;
        }
        
        if (!data.serviceCurrency) {
            $(`#${prefix}-service-currency`).addClass('is-invalid');
            $(`#${prefix}-service-currency`).after('<div class="invalid-feedback">الرجاء اختيار عملة الخدمة</div>');
            isValid = false;
        }
        
        if (!data.dollarPrice) {
            $(`#${prefix}-dollar-price`).addClass('is-invalid');
            $(`#${prefix}-dollar-price`).after('<div class="invalid-feedback">الرجاء إدخال السعر بالدولار</div>');
            isValid = false;
        }
        
        if (!data.sarPrice) {
            $(`#${prefix}-sar-price`).addClass('is-invalid');
            $(`#${prefix}-sar-price`).after('<div class="invalid-feedback">الرجاء إدخال السعر بالريال السعودي</div>');
            isValid = false;
        }
        
        if (!data.employeePrice) {
            $(`#${prefix}-employee-price`).addClass('is-invalid');
            $(`#${prefix}-employee-price`).after('<div class="invalid-feedback">الرجاء إدخال سعر الخدمة للموظف</div>');
            isValid = false;
        }
        
        if (!data.submitButtonName) {
            $(`#${prefix}-submit-button-name`).addClass('is-invalid');
            $(`#${prefix}-submit-button-name`).after('<div class="invalid-feedback">الرجاء إدخال اسم زر التقديم</div>');
            isValid = false;
        }
        
        if (!data.amountCalculation) {
            $(`#${prefix}-amount-calculation`).addClass('is-invalid');
            $(`#${prefix}-amount-calculation`).after('<div class="invalid-feedback">الرجاء إدخال حساب المبلغ</div>');
            isValid = false;
        }
        
        if (!data.commissionCalculation) {
            $(`#${prefix}-commission-calculation`).addClass('is-invalid');
            $(`#${prefix}-commission-calculation`).after('<div class="invalid-feedback">الرجاء إدخال حساب العمولة</div>');
            isValid = false;
        }
        
        // Validate service details (CKEditor content)
        if (!data.serviceDetails || data.serviceDetails.trim() === '') {
            // Add visual indicator for CKEditor validation
            const editorElement = $(`#${prefix}-service-details`).closest('.ck-editor');
            if (editorElement.length > 0) {
                editorElement.addClass('is-invalid');
                editorElement.after('<div class="invalid-feedback d-block">الرجاء إدخال تفاصيل الخدمة</div>');
            } else {
                $(`#${prefix}-service-details`).addClass('is-invalid');
                $(`#${prefix}-service-details`).after('<div class="invalid-feedback">الرجاء إدخال تفاصيل الخدمة</div>');
            }
            isValid = false;
        } else {
            // Remove invalid state if content exists
            const editorElement = $(`#${prefix}-service-details`).closest('.ck-editor');
            if (editorElement.length > 0) {
                editorElement.removeClass('is-invalid');
                const feedback = editorElement.next('.invalid-feedback');
                if (feedback.length > 0) {
                    feedback.remove();
                }
            }
        }
        
        if (!$(`#${prefix}-service-image`)[0].files.length && prefix === 'add') {
            $(`#${prefix}-service-image`).addClass('is-invalid');
            $(`#${prefix}-service-image`).after('<div class="invalid-feedback">الرجاء اختيار صورة</div>');
            isValid = false;
        }
        
        if (!data.iconColor) {
            $(`#${prefix}-icon-color`).addClass('is-invalid');
            $(`#${prefix}-icon-color`).after('<div class="invalid-feedback">الرجاء اختيار لون الايقونة</div>');
            isValid = false;
        }
        
        if (!data.iconBgColor) {
            $(`#${prefix}-icon-bg-color`).addClass('is-invalid');
            $(`#${prefix}-icon-bg-color`).after('<div class="invalid-feedback">الرجاء اختيار لون خلفية الايقونة</div>');
            isValid = false;
        }
        
        if (!data.textColor) {
            $(`#${prefix}-text-color`).addClass('is-invalid');
            $(`#${prefix}-text-color`).after('<div class="invalid-feedback">الرجاء اختيار لون النص</div>');
            isValid = false;
        }
        
        if (!data.textBgColor) {
            $(`#${prefix}-text-bg-color`).addClass('is-invalid');
            $(`#${prefix}-text-bg-color`).after('<div class="invalid-feedback">الرجاء اختيار لون خلفية النص</div>');
            isValid = false;
        }
        
        return isValid;
    }
    
    // Function to submit form via AJAX
    function submitFormViaAjax(data, prefix) {
        // Show loading indicator
        const submitBtn = $(`#${prefix}PackageModal .modal-footer .btn-primary`);
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
            $(`#${prefix}ServiceModal`).modal('hide');
            
            // Show success message
            alert('تم حفظ البيانات بنجاح');
            
            // Reload the DataTable
            dt.ajax.reload();
        }, 1500);
    }
    
    // Handle edit from view modal
    $('#editFromViewBtn').on('click', function() {
        $('#viewServiceModal').modal('hide');
        $('#editServiceModal').modal('show');
    });
});