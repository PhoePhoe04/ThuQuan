document.addEventListener("DOMContentLoaded", function () {
    const filterItems = document.querySelectorAll(".filter-item");
    const violationCards = document.querySelectorAll(".violation-card");

    filterItems.forEach(item => {
        item.addEventListener("click", () => {
            // Xóa class active khỏi tất cả filter
            filterItems.forEach(i => i.classList.remove("active"));
            item.classList.add("active");

            const filterType = item.getAttribute("data-type");

            violationCards.forEach(card => {
                const cardType = card.getAttribute("data-type");

                if (filterType === "all" || filterType === cardType) {
                    card.style.display = "block";
                } else {
                    card.style.display = "none";
                }
            });
        });
    });
});
