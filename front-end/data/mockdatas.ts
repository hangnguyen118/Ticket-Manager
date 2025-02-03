import { Menu, Movie } from "./types";

export const links: Menu[] = [
  { link: "/", label: "🍎 Home" },
  { link: "/cinema", label: "🍎 Cinemas" },
  {
    link: "/",
    label: "🍅 Features",
    links: [
      { link: "/docs", label: "🍌 Bananas" },
      { link: "/resources", label: "🍊 Oranges" },
      { link: "/community", label: "🥛 Milk" },
      { link: "/blog", label: "🍞 Bread" },
    ],
  },
  { link: "/movies", label: "🥚 List Movies" },
  { link: "/movies/1", label: "🍗 Detail" },
  {
    link: "#2",
    label: "🥩 Beef",
    links: [
      { link: "/faq", label: "🍗FAQ" },
      { link: "/demo", label: "🍗 Book a demo" },
      { link: "/forums", label: "🍗 Forums" },
    ],
  },
];

export const movies: Movie[] = [
  {
    title: "Bộ Tứ Báo Thủ",
    description:
      "Bộ tứ báo thủ bao gồm Chét-Xi-Cà, Dì Bốn, Cậu Mười Một, Con Kiều chính thức xuất hiện cùng với phi vụ báo thế kỉ. Nghe nói kế hoạch tiếp theo là ở Đà Lạt, liệu bốn báo thủ sẽ quậy Tết tung nóc cỡ nào?",
    genre: ["Hành động", "Hài", "Lãng mạng"],
    posterUrl:
      "https://cinema.momocdn.net/img/55117941458947931-botubaothu.jpg?size=M",
    release_day: "10/01/2025",
    duration: 180,
    rating: 1.5,
    age_rating: 18,
  },
  {
    title:
      "Nụ Hôn Bạc Tỷ Nụ Hôn Bạc Tỷ Nụ Hôn Bạc Tỷ Nụ Hôn Bạc Tỷ Nụ Hôn Bạc Tỷ Nụ Hôn Bạc Tỷ",
    description:
      "The story revolves around Vân, a bread seller who accidentally encounters two young men in a minor accident. What happens when love at first sight strikes all three of them simultaneously? Between a mature, manly guy and a slightly rebellious, cool one, who will win the ",
    genre: ["Hài Hước", "Chính kịch", "Lãng mạng"],
    posterUrl:
      "https://cinema.momocdn.net/img/31337174866614229-nhbt.jpg?size=M",
    release_day: "10/01/2025",
    duration: 180,
    rating: 1.5,
    age_rating: 18,
  },
  {
    title: "Paddington: Gấu Thủ Chu Du",
    description:
      "Paddington: Gấu Thủ Chu Du đưa khán giả theo chân chú gấu được nhiều người yêu mến, thích ăn mứt cam đang trong một chuyến phiêu lưu đầy mạo hiểm. Khi Paddington phát hiện ra dì Lucy yêu quý của mình đã biến mất khỏi Ngôi Nhà Dành Cho Các Chú Gấu Nghỉ Hưu, Paddington và gia đình Brown lên đường đến vùng hoang dã Peru để tìm kiếm, với manh mối duy nhất về nơi dì ấy ở là một điểm đánh dấu trên một bản đồ bí ẩn. Quyết tâm giải mã những bí mật đằng sau, Paddington bắt đầu một cuộc hành trình qua rừng nhiệt đới Amazon để tìm dì của mình... và có thể chú sẽ phát hiện ra một trong những kho báu huyền thoại nhất thế giới.",
    genre: ["Khoa học viễn tưởng", "Siêu nhiên"],
    posterUrl:
      "https://image.tmdb.org/t/p/w500/7yWE3f1zI8FlJI2tUDIRSnVHptY.jpg",
    release_day: "10/01/2025",
    duration: 180,
    rating: 1.5,
    age_rating: 18,
  },
  {
    title: "Mickey 17",
    description:
      "Được chuyển thể từ tiểu thuyết Mickey 7 của nhà văn Edward Ashton, Cuốn tiểu thuyết xoay quanh các phiên bản nhân bản vô tính mang tên “Mickey”, dùng để thay thế con người thực hiện cuộc chinh phạt nhằm thuộc địa hóa vương quốc băng giá Niflheim. Mỗi khi một Mickey chết đi, một Mickey mới sẽ được tạo ra, với phiên bản được đánh số 1, 2, 3 tiếp theo. Mickey số 7 được cho rằng đã chết, để rồi một ngày kia, hắn quay lại và bắt gặp phiên bản tiếp theo của mình.",
    genre: ["Kinh dị", "Rùng Rợn"],
    posterUrl:
      "https://cinema.momocdn.net/img/50706100909000337-pBpHjKGTsPFrlrR9nS0MJZ8hKL.jpg",
    release_day: "10/01/2025",
    duration: 180,
    rating: 1.5,
    age_rating: 18,
  },
  {
    title: "Nhà Gia Tiên",
    description:
      "Nhà Gia Tiên xoay quanh câu chuyện đa góc nhìn về các thế hệ khác nhau trong một gia đình, có hai nhân vật chính là Gia Minh (Huỳnh Lập) và Mỹ Tiên (Phương Mỹ Chi). Trở về căn nhà gia tiên để quay các video “triệu view” trên mạng xã hội, Mỹ Tiên - một nhà sáng tạo nội dung thuộc thế hệ Z vốn không tin vào chuyện tâm linh, hoàn toàn mất kết nối với gia đình, bất ngờ nhìn thấy",
    genre: ["Hành động", "Giật gân"],
    posterUrl:
      "https://image.tmdb.org/t/p/w500/yHdDgzEnFslwfwz2Hzc498lIhFx.jpg",
    release_day: "10/01/2025",
    duration: 180,
    rating: 1.5,
    age_rating: 18,
  },
  {
    title: "Vùng Đất Linh Hồn",
    description:
      "Bộ phim xoay quanh câu chuyện về Ogino Chihiro, một cô bé 10 tuổi luôn cảm thấy cuộc sống buồn chán. Sau đó, trong một lần chuyển nhà, tình cờ lạc đến một thành phố hoang vắng trong khi bố mẹ bị biến thành heo, Chihiro kinh hoàng phát hiện ra rằng mình bị mắc kẹt vào thế giới của những linh hồn và ma quỷ. Em ấy buộc phải tìm mọi cách để giải thoát bố mẹ và mình rồi trở về với thế giới loài người",
    genre: ["Hài hước", "Lãng mạng"],
    posterUrl:
      "https://image.tmdb.org/t/p/w500/pNHppsjxGBcRUCFlXQh0briymTN.jpg",
    release_day: "10/01/2025",
    duration: 180,
    rating: 1.5,
    age_rating: 18,
  },
];

export const cinemas = [
  {
      name: "Galaxy",
      url: "#",
      imageUrl: "https://th.bing.com/th/id/R.eed8e873ade1b1bbd5757d0a17cdbb56?rik=F0%2fTRX6O276mgQ&pid=ImgRaw&r=0"
  },
  {
      name: "Galaxy",
      url: "#",
      imageUrl: "https://th.bing.com/th/id/OIP.D2stMKldXfYLNWYtlXZb8QAAAA?rs=1&pid=ImgDetMain"
  },
  {
      name: "Galaxy",
      url: "#",
      imageUrl: "https://th.bing.com/th/id/OIP.1RbXSrF3sLYpmYpLa__wDgHaEF?rs=1&pid=ImgDetMain"
  },
  {
      name: "Galaxy",
      url: "#",
      imageUrl: "https://th.bing.com/th/id/R.6446be12ece075f6901dc200d16592eb?rik=y02nk4GCtPLF4A&pid=ImgRaw&r=0"
  },
  {
      name: "Galaxy",
      url: "#",
      imageUrl: "https://th.bing.com/th/id/OIP.paXGCXPfwlpuXNIu02Of6QHaFj?pid=ImgDet&w=474&h=355&rs=1"
  },
  {
      name: "Galaxy",
      url: "#",
      imageUrl: "https://th.bing.com/th/id/OIP.Sxe1CkTZ1F7wYEnUWudgQgHaFj?pid=ImgDet&w=474&h=355&rs=1"
  },
  {
      name: "Galaxy",
      url: "#",
      imageUrl: "https://th.bing.com/th/id/OIP.Sxe1CkTZ1F7wYEnUWudgQgHaFj?pid=ImgDet&w=474&h=355&rs=1"
  },
]
