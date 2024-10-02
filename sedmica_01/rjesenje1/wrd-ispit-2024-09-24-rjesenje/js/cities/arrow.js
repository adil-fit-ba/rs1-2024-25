generateArrow = (id) => {
    return `<svg id= ${"wind-indicator-" + id} xmlns="http://www.w3.org/2000/svg" width="100" height="100" viewBox="0 0 100 100">
    <polygon points="50,10 60,30 50,25 40,30" fill="black" />
    <rect x="48" y="30" width="4" height="50" fill="black" />
  </svg>`}