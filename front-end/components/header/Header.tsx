"use client"
import { Button, Group } from "@mantine/core";
import classes from "./Header.module.css";
import Logo from "./logo/Logo";
import NavLinks from "./navlinks/NavLinks";
import NavbarMobile from "./navmobile/NavMobile";

export default function Header() {
    return (
        <header className={classes.header}>
            <div className={classes.inner}>
                <Group justify="space-between">
                    <Logo />
                    <NavLinks />
                    <Group visibleFrom="sm">
                        <Button component="a" href="/auth" color="#E00000">Log in</Button>
                    </Group>
                    <NavbarMobile />
                </Group>
            </div>
        </header>
    )
}
