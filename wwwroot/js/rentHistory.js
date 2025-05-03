document.addEventListener('DOMContentLoaded', function() {
    const menu = document.getElementById('rentMenu');
    const tabs = menu.querySelectorAll('a');

    // Tạo indicator ban đầu
    const indicator = document.createElement('div');
    indicator.style.position = 'absolute';
    indicator.style.bottom = '0';
    indicator.style.height = '3px';
    indicator.style.backgroundColor = '#ee4d2d';
    indicator.style.borderRadius = '3px';
    indicator.style.transition = 'all 0.3s ease';
    menu.appendChild(indicator);

    // Kiểm tra xem có trạng thái tab nào đã lưu trong sessionStorage không
    const activeTabId = sessionStorage.getItem('activeTabId') || 'RentHistory';

    // Lấy tab dựa trên activeTabId
    const activeTab = menu.querySelector(`a[asp-action='${activeTabId}']`);
    if (activeTab) {
        activeTab.classList.add('active');
        updateIndicator(activeTab);
    }

    // Cập nhật indicator khi resize cửa sổ
    window.addEventListener('resize', function() {
        const activeTab = menu.querySelector('a.active');
        if (activeTab) {
            updateIndicator(activeTab);
        }
    });

    // Xử lý sự kiện click cho các tab
    tabs.forEach(tab => {
        tab.addEventListener('click', function(e) {
            // Xóa active từ tất cả các tab
            tabs.forEach(t => t.classList.remove('active'));

            // Thêm class active vào tab được click
            this.classList.add('active');

            // Cập nhật vị trí indicator
            updateIndicator(this);

            // Lưu lại trạng thái của tab đã click vào sessionStorage
            const tabId = this.getAttribute('asp-action');
            sessionStorage.setItem('activeTabId', tabId);

            // Điều hướng tới trang tương ứng
            if (tabId === 'RentHistory') {
                window.location.href = '/Account/Profile/RentHistory';
            } else if (tabId === 'ViolationHistory') {
                window.location.href = '/Account/Profile/ViolationHistory';
            }
        });
    });

    // Hàm cập nhật vị trí của indicator
    function updateIndicator(tab) {
        const tabRect = tab.getBoundingClientRect();
        const menuRect = menu.getBoundingClientRect();
        indicator.style.left = (tabRect.left - menuRect.left) + 'px';
        indicator.style.width = tabRect.width + 'px';
    }

    const filterItems = document.querySelectorAll('.filter-item');
    const violationCards = document.querySelectorAll('.violation-card');
    
    const filterMap = {
        'Tất cả': 'all',
        'Trễ hạn': 'late',
        'Hư hỏng': 'damaged', 
        'Mất sản phẩm': 'lost',
        'Không bảo quản': 'not-maintained',
        'Khác': 'other'
    };
    
    function filterViolations(displayText) {
        const filterValue = filterMap[displayText] || displayText.toLowerCase();
        
        document.querySelectorAll('.violation-card').forEach(card => {
            const cardFilterType = card.dataset.filterType;
            card.style.display = 
                filterValue === 'all' || 
                cardFilterType === filterValue ? 'block' : 'none';
        });
    }
    
    filterItems.forEach(item => {
        item.addEventListener('click', function() {
            filterItems.forEach(i => i.classList.remove('active'));
            this.classList.add('active');
            
            const filterType = this.getAttribute('data-type') || this.textContent.trim();
            filterViolations(filterType);
        });
    });
    
    // Kích hoạt mặc định
    const defaultFilter = document.querySelector('.filter-item.active');
    if (defaultFilter) {
        const filterType = defaultFilter.getAttribute('data-type') || 
                         defaultFilter.textContent.trim();
        filterViolations(filterType === 'Tất cả' ? 'all' : filterType);
    }

    // ========== XỬ LÝ NÚT HÀNH ĐỘNG ==========
    document.querySelectorAll('.violation-actions .btn').forEach(btn => {
        btn.addEventListener('click', function(e) {
            e.preventDefault();
            const card = this.closest('.violation-card');
            const violationId = card.querySelector('.violation-title').textContent;
            
            if (this.classList.contains('btn-outline')) {
                // Nút khiếu nại
                alert(`Mở form khiếu nại cho: ${violationId}`);
                // window.location.href = `/Appeal/Create?violationId=${violationId.replace('#', '')}`;
            } else {
                // Nút xem chi tiết
                alert(`Xem chi tiết vi phạm: ${violationId}`);
                // window.location.href = `/Violations/Detail/${violationId.replace('#', '')}`;
            }
        });
    });
});
