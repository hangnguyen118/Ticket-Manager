import { Menu } from "./types";

export const links: Menu[] = [
  { link: "/", label: "🍎 Apples" },
  {
    link: "/#",
    label: "🍅 Features",
    links: [
      { link: "/docs", label: "🍌 Bananas" },
      { link: "/resources", label: "🍊 Oranges" },
      { link: "/community", label: "🥛 Milk" },
      { link: "/blog", label: "🍞 Bread" },
    ],
  },
  { link: "/about", label: "🥚 Eggs" },
  { link: "/pricing", label: "🍗 Chicken" },
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
