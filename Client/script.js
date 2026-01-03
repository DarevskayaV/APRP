function sendData() {
        const firstName = document.getElementById("firstName").value;
        const lastName = document.getElementById("lastName").value;

        fetch("http://192.168.1.12:5106/api/form", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                firstName: firstName,
                lastName: lastName
            })
        })
        .then(async response => {
            const text = await response.text();
            if (!response.ok) {
                throw new Error(text);
            }
            document.getElementById("result").innerText = text;
        })
        .catch(error => {
            document.getElementById("result").innerText = error.message;
        });
    }