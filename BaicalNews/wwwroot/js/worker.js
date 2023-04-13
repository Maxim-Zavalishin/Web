window.onload = () => {

    modalController();
    /*let count = 1;

    
    getUsers();
    async function getUsers() {
        // отправляет запрос и получаем ответ
        const response = await fetch("/WorkerApi", {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
        // если запрос прошел нормально
        if (response.ok === true) {
            // получаем данные
            const getWorkers = await response.json();
            const Workers = getWorkers.value;
            const rows = document.querySelector("tbody");
            console.log(Workers);
            // добавляем полученные элементы в таблицу
            Workers.forEach(Worker => rows.append(row(Worker)));
        }
    }

    async function create(workerName, email, lastname, password, idRole) {

        const response = await fetch("/WorkerApi", {
            method: "POST",
            headers: { "Accept": "application/json", "Content-Type": "application/json" },
            body: JSON.stringify({
                name: workerName,
                lastname: lastname,
                email: email,
                password: password,
                idRole: parseInt(idRole, 10),
                
            })
        });
        if (response.ok === true) {
            let Workers = {
                name: workerName,
                lastname: lastname,
                email: email,
                password: password,
                idRole: parseInt(idRole, 10)
            };
            document.querySelector("tbody").append(row(Workers));
        }
        else {
            const error = await response.json();
            console.log(error.message);
        }
    }

    async function uppdate(id, name, email, lastname, password, idRole) {

    }

    function row(Worker) {
        const tr = document.createElement("tr");
        tr.setAttribute("data-rowid", Worker.id);

        const countTd = document.createElement("td");
        countTd.append(count);
        tr.append(countTd);
        count++;

        const nameTd = document.createElement("td");
        nameTd.append(Worker.name);
        tr.append(nameTd);

        const lastnameTd = document.createElement("td");
        lastnameTd.append(Worker.lastname);
        tr.append(lastnameTd);

        const emailTd = document.createElement("td");
        emailTd.append(Worker.email);
        tr.append(emailTd);

        const dataTd = document.createElement("td");
        dataTd.append(Worker.dateCreated);
        tr.append(dataTd);

        const roleIdTd = document.createElement("td");
        roleIdTd.append(Worker.idRole);
        tr.append(roleIdTd);

        const linksTd = document.createElement("td");

        const editLink = document.createElement("a");
        editLink.append("Изменить |")
        editLink.href =`/Worker/Save/${Worker.id}`;

        linksTd.append(editLink);

        const removeLink = document.createElement("a");
        if (Worker.id != 1)
            removeLink.append(" Удалить");
        removeLink.href = `/Worker/Delete/${Worker.id}`;

        linksTd.append(removeLink);
        tr.appendChild(linksTd);

        return tr;
    }

    let form_api = document.getElementById("formApi");

    if (form_api) {
        form_api.addEventListener("submit", async (e) => {
            e.preventDefault();
            const name = document.getElementById("workerName").value;
            const email = document.getElementById("workerEmail").value;
            const lastname = document.getElementById("workerLastname").value;
            const password = document.getElementById("workerPassword").value;
            const idRole = document.getElementById("workerIdRole").value;

            
            await create(name, email, lastname, password, idRole);
        });
    }


    let form__search = document.getElementById("form__search");

    if(form__search) {
        form__search.addEventListener("submit", async (e) => {
            e.preventDefault();
            const name = document.getElementById
        });
    }

    async function getUser(id) {
        const response = await fetch(`/WorkerApi`, {
            method: "GET",
            headers: { "Accept": "application/json" }
        });
        if (response.ok === true) {
            const worker = await response.json();
            id = worker.id;
            document.getElementById("workerName").value = worker.name;
            document.getElementById("workerEmail").value = worker.email;
            document.getElementById("workerLastname").value = worker.lastname;
            document.getElementById("workerPassword").value = worker.password;
            document.getElementById("workerIdRole").value = worker.idRole;
        }
        else {
            // если произошла ошибка, получаем сообщение об ошибке
            const error = await response.json();
            console.log(error.message); // и выводим его на консоль
        }
    }*/

    function modalController() {
        const btnElem = document.querySelector(".modal__open");
        const modalElem = document.querySelector(".__modal");
        const btnSave = document.querySelector(".save");
        
        btnElem.addEventListener('click', openModal);
        modalElem.addEventListener('click', closeModel);
    
        function openModal() {
            modalElem.style.opacity = 1;

            setTimeout(() => {modalElem.style.visibility = 'visible';}, 300)
        };
        
        function closeModel(event) {
            const target = event.target;

            if(target === modalElem || target === btnSave){
                modalElem.style.visibility = 'hidden';
                modalElem.style.opacity = 0;
            }
            
        } 
    }
}



