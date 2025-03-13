"use client"
import { Button, Group } from "@mantine/core";
import classes from "./Header.module.css";
import Logo from "./logo/Logo";
import NavbarMobile from "./navmobile/NavMobile";
import NavLinks from "./navlinks/NavLinks";
import Link from "next/link";

export default function Header() {
    return (
        <header className={classes.header}>
            <div className={classes.inner}>
                <Group justify="space-between">
                    <Logo />
                    <NavbarMobile hiddenFrom="sm" />
                </Group>
                <Group flex={1} justify="right" visibleFrom="sm">
                    <NavLinks/>
                    <Button component={Link} href="/auth" color="#E00000">Log in</Button>
                </Group>
            </div>
        </header>
    )
}
