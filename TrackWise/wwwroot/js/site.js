function setTransactionType(value) {
    document.querySelector('[name="Type"]').value = value;

    const buyBtn = document.getElementById("btnBuy");
    const sellBtn = document.getElementById("btnSell");

    buyBtn.classList.remove("active-buy");
    sellBtn.classList.remove("active-sell");

    if (value == 0) {
        buyBtn.classList.add("active-buy");
    } else {
        sellBtn.classList.add("active-sell");
    }
}

window.onload = () => {
    const selected = parseInt(document.querySelector('[name="Type"]').value || 0);
    setTransactionType(selected);
};
