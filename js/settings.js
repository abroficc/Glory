$(document).ready(function() {
    // Initialize DataTable
    if ($("#myTable").length) {
        const dt = $("#myTable").DataTable({
            paging: true, 
            lengthChange: false, 
            searching: false, 
            ordering: true, 
            info: true, 
            autoWidth: false, 
            responsive: true,
            pageLength: 10,
            language: {
                emptyTable: "لا توجد بيانات",
                info: "إظهار _START_ إلى _END_ من _TOTAL_ سجل",
                infoEmpty: "إظهار 0 إلى 0 من 0",
                paginate: { 
                    first:"الأولى", 
                    last:"الأخيرة", 
                    next:"التالي", 
                    previous:"السابق" 
                }
            }
        });
    }
    
    // Toggle filter section
    $('#toggleFilters').click(function() {
        $('#filterSection').toggle();
        var isVisible = $('#filterSection').is(':visible');
        $('#toggleFiltersText').text(isVisible ? 'إخفاء الفلترة' : 'إظهار الفلترة');
        $(this).find('i').toggleClass('ti-filter-off ti-filter');
    });
    
    // Add button - show add modal
    $('#openAddModal').click(function() {
        var modal = new bootstrap.Modal(document.getElementById('settingsModal'));
        modal.show();
    });
    
    // Close add modal buttons
    $('#closeModalTop').click(function() {
        var modal = bootstrap.Modal.getInstance(document.getElementById('settingsModal'));
        if (modal) {
            modal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('settingsModal')).hide();
        }
    });
    
    // Handle form submission for add modal
    $('#addSettingForm').on('submit', function(e) {
        e.preventDefault();
        
        // Get form values
        var settingName = $('#addSettingName').val();
        var settingValue = $('#addSettingValue').val();
        var settingDescription = $('#addSettingDescription').val();
        var settingGroup = $('#addSettingGroup').val();
        
        // Validate required fields
        if (!settingName || !settingValue) {
            showNotification('الرجاء ملء جميع الحقول المطلوبة', 'error');
            return;
        }
        
        // In a real application, you would submit the form data to the server
        showNotification('تم إضافة الإعداد بنجاح', 'success');
        
        // Close the modal
        var modal = bootstrap.Modal.getInstance(document.getElementById('settingsModal'));
        if (modal) {
            modal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('settingsModal')).hide();
        }
        
        // Reset form
        $('#addSettingForm')[0].reset();
    });
    
    // Handle save button click for add modal
    $('#saveBtn').click(function(e) {
        e.preventDefault();
        
        // In a real application, you would collect form data and submit it to the server
        showNotification('تم حفظ الإعدادات بنجاح', 'success');
        
        // Close the modal
        var modal = bootstrap.Modal.getInstance(document.getElementById('settingsModal'));
        if (modal) {
            modal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('settingsModal')).hide();
        }
    });
    
    // Reset filters
    $('#resetFilters').click(function() {
        $('#filter-setting-name').val('');
        $('#filter-setting-value').val('');
        $('#filter-setting-description').val('');
        $('#filter-setting-group').val('');
        showNotification('تم إعادة تعيين الفلاتر', 'success');
    });
    
    // Apply filters (search button)
    $('#searchButton').click(function() {
        // Get filter values
        var filterSettingName = $('#filter-setting-name').val();
        var filterSettingValue = $('#filter-setting-value').val();
        var filterSettingDescription = $('#filter-setting-description').val();
        var filterSettingGroup = $('#filter-setting-group').val();
        
        // In a real application, you would apply the filters here
        showNotification('سيتم تطبيق الفلاتر المحددة', 'info');
    });
    
    // Export to Excel button
    $('#exportExcelButton, #exportDataButton').click(function() {
        showNotification('سيتم تصدير البيانات إلى ملف Excel', 'info');
        // In a real application, you would implement Excel export functionality here
    });
    
    // Print button
    $('#printButton, #printReportButton').click(function() {
        showNotification('سيتم طباعة التقرير', 'info');
        // In a real application, you would implement print functionality here
    });
    
    // Advanced search button
    $('#advancedSearchButton').click(function() {
        showNotification('فتح نافذة البحث المتقدم', 'info');
        var modal = bootstrap.Modal.getInstance(document.getElementById('popupMenuModal'));
        if (modal) {
            modal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('popupMenuModal')).hide();
        }
    });
    
    // System settings button
    $('#systemSettingsButton').click(function() {
        showNotification('فتح إعدادات النظام', 'info');
        var modal = bootstrap.Modal.getInstance(document.getElementById('popupMenuModal'));
        if (modal) {
            modal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('popupMenuModal')).hide();
        }
    });
    
    // Help button
    $('#helpButton').click(function() {
        showNotification('فتح دليل المساعدة', 'info');
        var modal = bootstrap.Modal.getInstance(document.getElementById('popupMenuModal'));
        if (modal) {
            modal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('popupMenuModal')).hide();
        }
    });
    
    // Refresh button
    $('#refreshBtn').click(function() {
        showNotification('تحديث البيانات', 'info');
        // In a real application, you would refresh the table data here
    });
    
    // Select all checkboxes
    $('#selectAll').click(function() {
        $('.employee-checkbox').prop('checked', this.checked);
    });
    
    // Handle individual checkbox changes
    $('.employee-checkbox').change(function() {
        if ($('.employee-checkbox:checked').length === $('.employee-checkbox').length) {
            $('#selectAll').prop('checked', true);
        } else {
            $('#selectAll').prop('checked', false);
        }
    });
    
    // Delete selected button
    $('#deleteSelectedButton').click(function() {
        var selected = $('.employee-checkbox:checked');
        if (selected.length === 0) {
            showNotification('الرجاء تحديد إعدادات لحذفها', 'warning');
            return;
        }
        
        if (confirm('هل أنت متأكد من حذف ' + selected.length + ' إعدادات محددة؟')) {
            selected.closest('tr').remove();
            showNotification('تم حذف الإعدادات المحددة', 'success');
            $('#selectAll').prop('checked', false);
        }
    });
    
    // Top edit button
    $('#topEditButton').click(function() {
        var selected = $('.employee-checkbox:checked');
        if (selected.length === 0) {
            showNotification('الرجاء تحديد إعداد لتعديله', 'warning');
            return;
        }
        
        if (selected.length > 1) {
            showNotification('الرجاء تحديد إعداد واحد فقط للتعديل', 'warning');
            return;
        }
        
        // Get the setting data from the row
        var row = selected.closest('tr');
        var settingId = row.find('td:nth-child(2)').text();
        var settingName = row.find('td:nth-child(3)').text();
        var settingValue = row.find('td:nth-child(4)').text();
        var settingDescription = row.find('td:nth-child(5)').text();
        var settingGroup = row.find('td:nth-child(6)').text();
        
        // Populate the edit modal with setting data
        $('#editSettingId').val(settingId);
        $('#editSettingName').val(settingName);
        $('#editSettingValue').val(settingValue);
        $('#editSettingDescription').val(settingDescription);
        $('#editSettingGroup').val(settingGroup);
        
        // Show the edit modal
        var modal = new bootstrap.Modal(document.getElementById('editSettingModal'));
        modal.show();
    });
    
    // Top view button
    $('#topViewButton').click(function() {
        var selected = $('.employee-checkbox:checked');
        if (selected.length === 0) {
            showNotification('الرجاء تحديد إعداد لمشاهدته', 'warning');
            return;
        }
        
        if (selected.length > 1) {
            showNotification('الرجاء تحديد إعداد واحد فقط للمشاهدة', 'warning');
            return;
        }
        
        // Get the setting data from the row
        var row = selected.closest('tr');
        var settingName = row.find('td:nth-child(3)').text();
        var settingValue = row.find('td:nth-child(4)').text();
        var settingDescription = row.find('td:nth-child(5)').text();
        var settingGroup = row.find('td:nth-child(6)').text();
        var createDate = row.find('td:nth-child(7)').text();
        var modifyDate = row.find('td:nth-child(8)').text();
        
        // Populate the view modal with setting data
        $('#viewSettingName').val(settingName);
        $('#viewSettingValue').val(settingValue);
        $('#viewSettingDescription').val(settingDescription);
        $('#viewSettingGroup').val(settingGroup);
        $('#viewCreateDate').val(createDate);
        $('#viewModifyDate').val(modifyDate);
        
        // Show the view modal
        var modal = new bootstrap.Modal(document.getElementById('viewSettingModal'));
        modal.show();
    });
    
    // Handle form submission for edit modal
    $('#editSettingForm').on('submit', function(e) {
        e.preventDefault();
        
        // Get form values
        var settingId = $('#editSettingId').val();
        var settingName = $('#editSettingName').val();
        var settingValue = $('#editSettingValue').val();
        var settingDescription = $('#editSettingDescription').val();
        var settingGroup = $('#editSettingGroup').val();
        
        // Validate required fields
        if (!settingName || !settingValue) {
            showNotification('الرجاء ملء جميع الحقول المطلوبة', 'error');
            return;
        }
        
        // In a real application, you would submit the form data to the server
        showNotification('تم حفظ التعديلات بنجاح', 'success');
        
        // Close the modal
        var modal = bootstrap.Modal.getInstance(document.getElementById('editSettingModal'));
        if (modal) {
            modal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('editSettingModal')).hide();
        }
    });
    
    // Handle edit from view modal
    $('#editFromViewBtn').on('click', function() {
        // Get values from view modal
        var settingName = $('#viewSettingName').val();
        var settingValue = $('#viewSettingValue').val();
        var settingDescription = $('#viewSettingDescription').val();
        var settingGroup = $('#viewSettingGroup').val();
        
        // Close view modal
        var viewModal = bootstrap.Modal.getInstance(document.getElementById('viewSettingModal'));
        if (viewModal) {
            viewModal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('viewSettingModal')).hide();
        }
        
        // Set values in edit modal
        $('#editSettingName').val(settingName);
        $('#editSettingValue').val(settingValue);
        $('#editSettingDescription').val(settingDescription);
        $('#editSettingGroup').val(settingGroup);
        
        // Show edit modal
        var editModal = new bootstrap.Modal(document.getElementById('editSettingModal'));
        editModal.show();
    });
    
    // Handle view action from dropdown menu
    $('tbody').on('click', '[data-action="view"]', function(e) {
        e.preventDefault();
        
        // Get the setting data from the row
        var row = $(this).closest('tr');
        var settingName = row.find('td:nth-child(3)').text();
        var settingValue = row.find('td:nth-child(4)').text();
        var settingDescription = row.find('td:nth-child(5)').text();
        var settingGroup = row.find('td:nth-child(6)').text();
        var createDate = row.find('td:nth-child(7)').text();
        var modifyDate = row.find('td:nth-child(8)').text();
        
        // Populate the view modal with setting data
        $('#viewSettingName').val(settingName);
        $('#viewSettingValue').val(settingValue);
        $('#viewSettingDescription').val(settingDescription);
        $('#viewSettingGroup').val(settingGroup);
        $('#viewCreateDate').val(createDate);
        $('#viewModifyDate').val(modifyDate);
        
        // Show the view modal
        var modal = new bootstrap.Modal(document.getElementById('viewSettingModal'));
        modal.show();
    });
    
    // Handle edit action from dropdown menu
    $('tbody').on('click', '[data-action="edit"]', function(e) {
        e.preventDefault();
        
        // Get the setting data from the row
        var row = $(this).closest('tr');
        var settingId = row.find('td:nth-child(2)').text();
        var settingName = row.find('td:nth-child(3)').text();
        var settingValue = row.find('td:nth-child(4)').text();
        var settingDescription = row.find('td:nth-child(5)').text();
        var settingGroup = row.find('td:nth-child(6)').text();
        
        // Populate the edit modal with setting data
        $('#editSettingId').val(settingId);
        $('#editSettingName').val(settingName);
        $('#editSettingValue').val(settingValue);
        $('#editSettingDescription').val(settingDescription);
        $('#editSettingGroup').val(settingGroup);
        
        // Show the edit modal
        var modal = new bootstrap.Modal(document.getElementById('editSettingModal'));
        modal.show();
    });
    
    // Handle delete action from dropdown menu
    $('tbody').on('click', '[data-action="delete"]', function(e) {
        e.preventDefault();
        
        // Get the setting data from the row
        var row = $(this).closest('tr');
        var settingId = row.find('td:nth-child(2)').text();
        var settingName = row.find('td:nth-child(3)').text();
        
        // Confirm deletion
        if (confirm('هل أنت متأكد من حذف الإعداد "' + settingName + '"?')) {
            // Remove the row from the table
            row.remove();
            
            // Show success message
            showNotification('تم حذف الإعداد بنجاح', 'success');
        }
    });
    
    // Save basic settings function - triggers the form submission
    function saveBasicSettings() {
        // Trigger the form submission
        $('#basicSettingsForm').submit();
    }

    // Handle form submission for the basic settings form
    $('#basicSettingsForm').on('submit', function(e) {
        e.preventDefault();
        
        // Get all form values
        var formData = $(this).serialize();
        
        // In a real application, you would submit the form data to the server
        showNotification('تم حفظ الإعدادات بنجاح', 'success');
        
        // Close the modal
        var modal = bootstrap.Modal.getInstance(document.getElementById('basicSettingsModal'));
        if (modal) {
            modal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('basicSettingsModal')).hide();
        }
    });

    // Initialize bootstrap-select for dropdowns in the basic settings modal
    function initializeSelectPicker() {
        $('.selectpicker').selectpicker({
            style: 'btn-light',
            liveSearch: true,
            liveSearchPlaceholder: 'ابحث...',
            noneSelectedText: 'لم يتم تحديد أي شيء',
            noneResultsText: 'لا توجد نتائج لـ {0}',
            selectAllText: 'تحديد الكل',
            deselectAllText: 'إلغاء تحديد الكل',
            dropupAuto: false,
            width: '100%',
            container: 'body'
        });
    }
    
    // Initialize selectpickers when document is ready
    initializeSelectPicker();
    
    // Re-initialize bootstrap-select when modals are shown
    $('.modal').on('shown.bs.modal', function () {
        $('.selectpicker').selectpicker('refresh');
    });
    
    // Make saveBasicSettings function globally accessible
    window.saveBasicSettings = saveBasicSettings;
    
    // Notification function
    function showNotification(message, type) {
        // Create a temporary notification element
        var alertClass = 'alert-info';
        if (type === 'success') alertClass = 'alert-success';
        if (type === 'warning') alertClass = 'alert-warning';
        if (type === 'error') alertClass = 'alert-danger';
        
        var notification = $(`
            <div class="alert ${alertClass} alert-dismissible fade show settings-notification" 
                 role="alert">
                ${message}
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            </div>
        `);
        
        // Add to body
        $('body').append(notification);
        
        // Auto remove after 3 seconds
        setTimeout(function() {
            notification.fadeOut(function() {
                notification.remove();
            });
        }, 3000);
    }
    
    // Preview design function
    function previewDesign() {
        const id = document.getElementById('designNum').value;
        if (id) {
            const url = "http://alamayiz.yrbso.app/index?yr=" + id;
            window.open(url, '_blank');
        } else {
            alert("يرجى إدخال رقم التصميم أولا");
        }
    }
    
    // Re-initialize bootstrap-select when modals are shown
    $('.modal').on('shown.bs.modal', function () {
        $('.selectpicker').selectpicker('refresh');
    });
    
    // Make saveBasicSettings function globally accessible
    window.saveBasicSettings = saveBasicSettings;

});