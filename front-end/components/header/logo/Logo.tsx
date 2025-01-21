import Image from "next/image";
import Link from "next/link";

export default function Logo() {
    return (
        <Link href="/">
            <Image src="/images/bird_logo.webp" alt="LOGO" width={30} height={30} />
        </Link>
    )
}
