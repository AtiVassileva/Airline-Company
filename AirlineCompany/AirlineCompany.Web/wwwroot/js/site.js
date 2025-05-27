document.addEventListener('DOMContentLoaded', function () {

    document.querySelectorAll('.nav-item.dropdown').forEach(function (dropdown) {

        const toggle = dropdown.querySelector('[data-bs-toggle="dropdown"]');
        const bsDropdown = bootstrap.Dropdown.getOrCreateInstance(toggle);

        dropdown.addEventListener('mouseenter', function () {
            bsDropdown.show();
        });
        dropdown.addEventListener('mouseleave', function () {
            bsDropdown.hide();
        });
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const deleteModal = document.getElementById('deleteModal');
    if (!deleteModal) return;

    deleteModal.addEventListener('show.bs.modal', function (event) {
        const button = event.relatedTarget;
        const itemName = button.getAttribute('data-item-name') || 'този елемент';
        const deleteUrl = button.getAttribute('data-delete-url');

        const modalItemName = deleteModal.querySelector('#deleteItemName');
        const form = deleteModal.querySelector('#deleteForm');

        modalItemName.textContent = itemName;
        form.action = deleteUrl;
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const roleModal = document.getElementById('roleModal');
    if (!roleModal) return;

    roleModal.addEventListener('show.bs.modal', function (event) {
        const button = event.relatedTarget;
        const itemName = button.getAttribute('data-item-name') || 'този елемент';
        const changeRoleUrl = button.getAttribute('data-role-url');

        const modalItemName = roleModal.querySelector('#roleItemName');
        const form = roleModal.querySelector('#roleForm');

        modalItemName.textContent = itemName;
        form.action = changeRoleUrl;
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const cancelModal = document.getElementById('cancelModal');
    if (!cancelModal) return;

    cancelModal.addEventListener('show.bs.modal', function (event) {
        const button = event.relatedTarget;
        const itemName = button.getAttribute('data-item-name') || 'този елемент';
        const cancelUrl = button.getAttribute('data-cancel-url');

        const modalItemName = cancelModal.querySelector('#cancelItemName');
        const form = cancelModal.querySelector('#cancelForm');

        modalItemName.textContent = itemName;
        form.action = cancelUrl;
    });
});

document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("searchInput");

    if (searchInput) {
        searchInput.addEventListener("keyup", function () {
            const query = this.value.toLowerCase();
            const rows = document.querySelectorAll("#usersTable tbody tr");

            rows.forEach(row => {
                const email = row.cells[0].innerText.toLowerCase();
                row.style.display = email.includes(query) ? "" : "none";
            });
        });
    }
});

document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("searchPlanesInput");

    if (searchInput) {
        searchInput.addEventListener("keyup", function () {
            const query = this.value.toLowerCase();
            const rows = document.querySelectorAll("#planesTable tbody tr");

            rows.forEach(row => {
                const email = row.cells[0].innerText.toLowerCase();
                row.style.display = email.includes(query) ? "" : "none";
            });
        });
    }
});

document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("searchDestinationsInput");

    if (searchInput) {
        searchInput.addEventListener("keyup", function () {
            const query = this.value.toLowerCase();
            const rows = document.querySelectorAll("#destinationsTable tbody tr");

            rows.forEach(row => {
                const email = row.cells[0].innerText.toLowerCase();
                row.style.display = email.includes(query) ? "" : "none";
            });
        });
    }
});

document.addEventListener("DOMContentLoaded", function () {
    const countryFilter = document.getElementById("countryFilter");
    const table = document.getElementById("destinationsTable");
    const rows = table.getElementsByTagName("tr");

    countryFilter.addEventListener("change", function () {
        const selectedCountry = this.value.toLowerCase();

        for (let i = 1; i < rows.length; i++) {
            const cells = rows[i].getElementsByTagName("td");
            if (cells.length < 3) continue;

            const country = cells[1].textContent.toLowerCase();
            const match = selectedCountry === "" || country === selectedCountry;

            rows[i].style.display = match ? "" : "none";
        }
    });
});