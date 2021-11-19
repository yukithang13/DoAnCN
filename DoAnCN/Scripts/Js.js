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
const testimonialsContainer = document.querySelector(".testimonials-container");
const testimonial = document.querySelector(".testimonial");
const userImage = document.querySelector(".user-image");
const username = document.querySelector(".username");
const role = document.querySelector(".role");

const testimonials = [
    {
        name: "Thanh Hồng",
        position: "",
        photo:
            "https://danongonline.com.vn/wp-content/uploads/2018/02/anh-girl-xinh-9-1.jpg",
        text:
            "Dịch vụ chăm sóc khách hàng tốt. Sự đồng cảm, quan tâm tới khách hàng trong toàn bộ các giai đoạn trước, trong, sau khi họ sử dụng dịch vụ.",
    },
    {
        name: "Bích Huyền",
        position: "",
        photo: "https://hoangdaokimgiap.vn/anh-gai-xinh/imager_11_8527_700.jpg",
        text:
            "Cảnh quan môi trường và cơ sở vật chất tuyệt vời. Phong cảnh độc đáo, đa dạng.",
    },
    {
        name: "Thúy Hằng",
        position: "",
        photo: "https://itcafe.vn/wp-content/uploads/2021/01/anh-gai-xinh-2.jpg",
        text:
            "Thức ăn ngon, hợp khẩu vị. Nhân viên có kiến thức về an toàn, an ninh và có kỹ năng quan sát.",
    },
    {
        name: "Cẩm Viên",
        position: "",
        photo: "https://4.bp.blogspot.com/-3gTX68tFh1I/WzjXo3ItQtI/AAAAAAAAwXM/c3CUimqg4D4U3-IoMzgksfjmEZxByIXIgCLcBGAs/s640/anh-hot-gril-lanh-lung-1.jpg",
        text:
            "Vui chơi giải trí phong phú, đa dạng. Tham quan vườn trái cây thú vị. Đặc sản phong phú, đa dạng.",
    },
    {
        name: "Nguyễn Thị Thu",
        position: "",
        photo: "https://kenh14cdn.com/thumb_w/660/2019/3/24/5451948722551103147424772114672588939591680n-1553406715068621869667.jpg",
        text:
            "Tôi đã từng đi du lịch rất nhiều nhưng công ty này làm tôi rất hài lòng từ thiết kế tour tới khách sạn ăn uống rất là được",
    },
    {
        name: "Phạm Anh Tuấn",
        position: "",
        photo:
            "https://mrhanhphuc.com/uploaded/uploads/2017/09/cach-tao-dang-chup-anh-dep-cho-nam10.jpg",
        text:
            "Tận tình, chu đáo từ ăn , chơi đến khách sạn , hướng dẫn viên thân thiện có kiến thức du lịch rất giỏi .",
    },
    {
        name: "Lê Vi",
        position: "",
        photo: "https://luv.vn/wp-content/uploads/2021/02/Hinh-anh-hot-girl-hoc-sinh-de-thuong-nhat-6.jpg",
        text:
            "Du lịch giá rẻ, hướng dẫn rất nhiệt tình thân thiện",
    },
    {
        name: "Hoa Nhi",
        position: "",
        photo: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4QQCo4hrKa1H09DC0isy1N2PCCOLrxVvkk2Cy_dwhH0cOvu68q0p-2QM1-vrv9xhP4_g&usqp=CAU",
        text:
            "Đã đi nhiều nơi, nhưng đây là lần đầu thấy HDV nhiệt tình, tận tâm với khách đến vậy. Cám ơn cty, cám ơn 2 anh em HDV, chúc cty ngày càng có nhiều HDV có tâm như thế, chúc 2 anh em HDV có nhiều sức khỏe, luôn giữ dc lửa nghề.",
    },
];






let index = 1;

const updateTestimonial = () => {
    const { name, position, photo, text } = testimonials[index];
    testimonial.innerHTML = text;
    userImage.src = photo;
    username.innerHTML = name;
    role.innerHTML = position;
    index++;
    if (index > testimonials.length - 1) index = 0;
};

setInterval(updateTestimonial, 5000);

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
