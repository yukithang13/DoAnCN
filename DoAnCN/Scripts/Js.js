window.addEventListener("scroll", function(){
    var navbar = document.querySelector("nav");
    navbar.classList.toggle("sticky",window.scrollY > 0);
    
})

//map
let map;

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: 10.876575, lng: 106.800090 },
        zoom: 17,
    });
}


//slider
$('.autoplay').slick({
    slidesToShow: 3,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 2000,
});
//change background
function changeBg() {

    const images = [
        'url("/Content/images/2.jpg")',
        'url("/Content/images/3.jpg")',
        'url("/Content/images/4.jpg")',   
        'url("/Content/images/5.jpg")',   
        'url("/Content/images/about-us.jpg")',

    ]

    const home = document.getElementById('home');
    const bg = images[Math.floor(Math.random() * images.length)];

    home.style.backgroundImage = bg;
    
}

setInterval(changeBg, 5000);
