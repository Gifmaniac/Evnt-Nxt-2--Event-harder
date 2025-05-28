// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function updateTotalPrice(ticketID, ticketPrice) {
    const quantityInput = document.getElementById(`quantity-${ticketID}`);
    const available = parseInt(quantityInput.dataset.available);
    const totalPriceDisplay = document.getElementById(`totalPrice-${ticketID}`);

    const quantity = parseInt(quantityInput.value) || 0;
    const total = ticketPrice * quantity;

    totalPriceDisplay.textContent = `Total: €{total}`;

    if (quantity > available) {
        message.textContent = "There are not enough tickets available for your current order, try lowering your order.";
    } else {
        message.textContent = "Buy now!";
    }
}