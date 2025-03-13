"use client"
import { Burger, Button, Divider, Drawer, Group, ScrollArea } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import { links } from "@/data/mockdatas";
import Link from "next/link";
import NavMobileMenu from "./NavMobileMenu";

export default function NavbarMobile({ ...rest }) {
    const [drawerOpened, { toggle: toggleDrawer, close: closeDrawer }] = useDisclosure(false);

    const items = links.map((item, index) => (
        <NavMobileMenu item={item} key={index} link={item.link}></NavMobileMenu>
    ));
    return (
        <Group {...rest}>
            <Drawer
                opened={drawerOpened}
                onClose={closeDrawer}
                size="100%"
                padding="md"
                zIndex={1000000}
                title="Menu"
            >
                <ScrollArea h="calc(100vh - 80px" mx="-md" type="always">
                    {items}
                    <Divider my="sm" />
                    <Group justify="center" grow pb="xl" px="md">
                        <Button component={Link} href="/auth" variant="default">Log in</Button>
                        <Button component={Link} href="/auth" color="#E00000">Sign up</Button>
                    </Group>
                </ScrollArea>
            </Drawer>
            <Burger opened={drawerOpened} onClick={toggleDrawer} aria-label="Toggle navigation" size="sm" />
        </Group>
    )
}
