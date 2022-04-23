const send = async (e) => {
    e.preventDefault();
    const response = await fetch("/api/user", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            name: document.getElementById("userName").value,
            age: document.getElementById("userAge").value
        })
    });
    const message = await response.json();
    document.getElementById("message").innerText = message.text;
}

document.getElementById("sendBtn").addEventListener("click", send);