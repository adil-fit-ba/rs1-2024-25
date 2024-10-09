generatePropeler = (id) => {
    return `<svg id=${"propeller-" + id} class="propeller" viewBox="0 0 100 100" xmlns="http://www.w3.org/2000/svg">
<circle cx="50" cy="50" r="45" fill="lightblue" />
<line x1="50" y1="5" x2="50" y2="30" stroke="black" stroke-width="3" />
<line x1="50" y1="70" x2="50" y2="95" stroke="black" stroke-width="3" />
<line x1="5" y1="50" x2="30" y2="50" stroke="black" stroke-width="3" />
<line x1="70" y1="50" x2="95" y2="50" stroke="black" stroke-width="3" />
<circle cx="50" cy="50" r="5" fill="black" />
</svg>`}