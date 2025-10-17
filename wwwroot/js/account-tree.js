// Account Tree JavaScript functionality
$(document).ready(function() {
    // Initialize tooltips safely for Bootstrap 5
    if (typeof bootstrap !== 'undefined' && $.fn.tooltip) {
        $('[data-bs-toggle="tooltip"]').tooltip();
    }
    
    // Auto focus first input when any modal is shown
    $('.modal').on('shown.bs.modal', function () {
        $(this).find('input:first').trigger('focus');
    });
    
    // Reset filters - generalized approach
    $('#resetFilters').on('click', function() {
        $('#filterSection').find('input, select').val('');
        // TODO: إعادة تحميل البيانات هنا
    });
    
    // Apply filters
    $('#applyFilters').on('click', function() {
        var nameFilter = $('#filter-name').val().toLowerCase();
        var phoneFilter = $('#filter-phone').val().toLowerCase();
        var accountFilter = $('#filter-account').val().toLowerCase();
        
        // In a real implementation, you would filter the tree data here
        alert('سيتم تطبيق الفلاتر: اسم الحساب "' + nameFilter + '", رقم الهاتف "' + phoneFilter + '", الحساب "' + accountFilter + '"');
    });
    
    // Refresh button
    $('#refreshBtn').on('click', function() {
        location.reload();
    });
    
    // Save account button - for the new accounts modal
    $('#accountTreeAccountsModal .btn-success').on('click', function() {
        // In a real implementation, you would submit the form data to the server
        alert('تم حفظ الحساب الجديد!');
        var modal = bootstrap.Modal.getInstance(document.getElementById('accountTreeAccountsModal'));
        if (modal) {
            modal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('accountTreeAccountsModal')).hide();
        }
        // Reset form if needed
        $('#accountTreeAccountsModal form')[0].reset();
    });
    
    // Save edit account button
    $('#accountTreeSaveEditAccountBtn').on('click', function() {
        // In a real implementation, you would submit the form data to the server
        alert('تم حفظ التعديلات!');
        var modal = bootstrap.Modal.getInstance(document.getElementById('accountTreeEditAccountModal'));
        if (modal) {
            modal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('accountTreeEditAccountModal')).hide();
        }
    });
    
    // Edit from view modal
    $('#accountTreeEditFromViewBtn').on('click', function() {
        var viewModal = bootstrap.Modal.getInstance(document.getElementById('accountTreeViewAccountModal'));
        if (viewModal) {
            viewModal.hide();
        } else {
            new bootstrap.Modal(document.getElementById('accountTreeViewAccountModal')).hide();
        }
        var editModal = new bootstrap.Modal(document.getElementById('accountTreeEditAccountModal'));
        editModal.show();
    });
    
    // Print account
    $('#accountTreePrintAccountBtn').on('click', function() {
        var accountName = $('#accountTreeViewAccountName').text();
        alert('طباعة بيانات الحساب: ' + accountName);
    });
    
    // Top action buttons
    $('#topViewButton').on('click', function(e) {
        e.preventDefault();
        alert('الرجاء تحديد حساب من الشجرة لعرضه');
    });
    
    $('#topEditButton').on('click', function(e) {
        e.preventDefault();
        alert('الرجاء تحديد حساب من الشجرة لتعديله');
    });
    
    // Popup menu actions
    $('#popupMenuModal').on('click', '.btn', function() {
        var buttonText = $(this).text().trim();
        
        if (buttonText.includes('تصدير')) {
            alert('تصدير شجرة الحسابات إلى ملف');
        } else if (buttonText.includes('طباعة')) {
            alert('طباعة تقارير الحسابات');
        } else if (buttonText.includes('بحث')) {
            alert('فتح نافذة البحث المتقدم');
        } else if (buttonText.includes('إعدادات')) {
            alert('فتح إعدادات شجرة الحسابات');
        } else if (buttonText.includes('مساعدة')) {
            alert('عرض دليل المستخدم ومساعدة النظام');
        }
    });
    
    // Handle view action from dropdown menu using delegated events
    $('tbody').on('click', '[data-action="view"]', function(e) {
        e.preventDefault();
        
        // Get the account data from the row
        var row = $(this).closest('tr');
        var accountName = row.find('td:nth-child(3)').text();
        var accountCode = row.find('td:nth-child(4)').text();
        var parentAccount = row.find('td:nth-child(5)').text();
        var accountType = row.find('td:nth-child(6)').text();
        var accountSide = row.find('td:nth-child(7)').text();
        var accountNature = row.find('td:nth-child(8)').text();
        
        // Populate the view modal with account data
        $('#accountTreeViewAccountName').text(accountName);
        $('#accountTreeViewAccountCode').text(accountCode);
        $('#accountTreeViewParentAccount').text(parentAccount);
        $('#accountTreeViewAccountType').text(accountType);
        $('#accountTreeViewAccountSide').text(accountSide);
        $('#accountTreeViewAccountNature').text(accountNature);
        // For group, employee - these would be populated from actual data
        $('#accountTreeViewGroup').text('غير محدد');
        $('#accountTreeViewEmployee').text('غير محدد');
        
        // Show the view modal
        var modal = new bootstrap.Modal(document.getElementById('accountTreeViewAccountModal'));
        modal.show();
    });
    
    // Handle edit action from dropdown menu using delegated events
    $('tbody').on('click', '[data-action="edit"]', function(e) {
        e.preventDefault();
        
        // Get the account data from the row
        var row = $(this).closest('tr');
        var accountName = row.find('td:nth-child(3)').text();
        var accountCode = row.find('td:nth-child(4)').text();
        var parentAccount = row.find('td:nth-child(5)').text();
        var accountType = row.find('td:nth-child(6)').text();
        var accountSide = row.find('td:nth-child(7)').text();
        var accountNature = row.find('td:nth-child(8)').text();
        
        // Populate the edit modal with account data
        $('#accountTreeEditAccountName').val(accountName);
        $('#accountTreeEditAccountCode').val(accountCode);
        
        // Set parent account selection
        $('#accountTreeEditParentAccount option').each(function() {
            if ($(this).text() === parentAccount) {
                $(this).prop('selected', true);
                return false;
            }
        });
        
        // Set account type selection
        if (accountType === 'أصول') {
            $('#accountTreeEditAccountTypeMain').prop('checked', true);
        } else {
            $('#accountTreeEditAccountTypeSub').prop('checked', true);
        }
        
        // Set account side selection
        if (accountSide === 'شمال') {
            $('#accountTreeEditSideNorth').prop('checked', true);
        } else if (accountSide === 'جنوب') {
            $('#accountTreeEditSideSouth').prop('checked', true);
        } else {
            $('#accountTreeEditSideNone').prop('checked', true);
        }
        
        // Set account nature selection
        if (accountNature === 'ميزانية عمومية') {
            $('#accountTreeEditNatureBalance').prop('checked', true);
        } else {
            $('#accountTreeEditNatureIncome').prop('checked', true);
        }
        
        // For group, employee - these would be set from actual data
        $('#accountTreeEditGroup').val('');
        $('#accountTreeEditEmployee').val('');
        
        // Show the edit modal
        var modal = new bootstrap.Modal(document.getElementById('accountTreeEditAccountModal'));
        modal.show();
    });
    
    // Handle view action from context menu
    function viewAccount(node) {
        // Populate the view modal with account data
        $('#accountTreeViewAccountName').text(node.text);
        $('#accountTreeViewAccountCode').text('1001'); // TODO: Replace with real account data from AJAX or server
        $('#accountTreeViewParentAccount').text('الأصول'); // TODO: Replace with real account data from AJAX or server
        $('#accountTreeViewAccountType').text('فرعي'); // TODO: Replace with real account data from AJAX or server
        $('#accountTreeViewAccountSide').text('بدون'); // TODO: Replace with real account data from AJAX or server
        $('#accountTreeViewAccountNature').text('ميزانية عمومية'); // TODO: Replace with real account data from AJAX or server
        $('#accountTreeViewGroup').text('غير محدد'); // TODO: Replace with real account data from AJAX or server
        $('#accountTreeViewEmployee').text('غير محدد'); // TODO: Replace with real account data from AJAX or server
        
        // Show the view modal
        var modal = new bootstrap.Modal(document.getElementById('accountTreeViewAccountModal'));
        modal.show();
    }
    
    // Handle edit action from context menu
    function editAccount(node) {
        // Populate the edit modal with account data
        $('#accountTreeEditAccountName').val(node.text);
        $('#accountTreeEditAccountCode').val('1001'); // TODO: Replace with real account data from AJAX or server
        $('#accountTreeEditParentAccount').val('1'); // TODO: Replace with real account data from AJAX or server
        $('#accountTreeEditAccountTypeSub').prop('checked', true); // TODO: Replace with real account data from AJAX or server
        $('#accountTreeEditSideNone').prop('checked', true); // TODO: Replace with real account data from AJAX or server
        $('#accountTreeEditNatureBalance').prop('checked', true); // TODO: Replace with real account data from AJAX or server
        $('#accountTreeEditGroup').val(''); // TODO: Replace with real account data from AJAX or server
        $('#accountTreeEditEmployee').val(''); // TODO: Replace with real account data from AJAX or server
        
        // Show the edit modal
        var modal = new bootstrap.Modal(document.getElementById('accountTreeEditAccountModal'));
        modal.show();
    }
    
    // Handle delete action from context menu
    function deleteAccount(node) {
        if (confirm('هل أنت متأكد من حذف هذا الحساب؟')) {
            // In a real application, you would send a request to the server to delete the account
            alert('تم حذف الحساب بنجاح!');
        }
    }
});