const url = "https://localhost:5001/api/beanvariety/";
const api = "https://localhost:5001/api";

const mainContainer = document.querySelector("#content");
const addBeanButton = document.querySelector("#addBean");
const button = document.querySelector("#run-button");
button.addEventListener("click", () => {
    displayData();
});
addBeanButton.addEventListener("click", () => {
    const bean = {
        name: document.querySelector("input[name='beanName']").value,
        region: document.querySelector("input[name='beanRegion']").value,
        notes: document.querySelector("input[name='beanNotes']").value,
    };
    postBeanVariety(bean);
});

function getAllBeanVarieties() {
    return fetch(url).then((resp) => resp.json());
}

const getAllCoffees = () => {
    return fetch(`${api}/coffee`).then((res) => res.json());
};

const postBeanVariety = (bean) => {
    return fetch(`${api}/beanVariety/`, postOptions(bean));
};

const displayData = () => {
    getAllBeanVarieties().then((beanVarieties) => {
        getAllCoffees().then((coffees) => {
            console.log(coffees);
            console.log(beanVarieties);
            mainContainer.innerHTML = "";
            for (const c of coffees) {
                mainContainer.innerHTML += `<p>Coffee ${c.id}: ${c.title} (${c.beanVariety.name})</p>`;
            }
            mainContainer.innerHTML += `<p>All Varieties: </p>
            <ul>`;
            for (const bv of beanVarieties) {
                mainContainer.innerHTML += `<li>Variety ${bv.id}: ${bv.name} (${bv.region}) [${bv.notes}]</li>`;
            }
            mainContainer.innerHTML += `</ul>`;
        });
    });
};

const postOptions = (object) => {
    return {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(object),
    };
};
