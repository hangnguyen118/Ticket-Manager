import Link from "next/link";
import classes from "./MenuItem.module.css";

export default function MenuItem({ link, children }: Readonly<{ link:string, children: React.ReactNode; }>) {
    return (
        <Link href={link} className={classes.wrapper}>
            {children}
        </Link>
    )
}
