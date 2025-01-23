"use client"

import { Burger, Button, Divider, Drawer, Group, ScrollArea } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import { links } from "@/data/mockdatas";
import MenuItem from "../menuItem/MenuItem";

export default function NavbarMobile() {
    const [drawerOpened, { toggle: toggleDrawer, close: closeDrawer }] = useDisclosure(false);
    const items = links.map(({ label, link, links }, index) => (
        <MenuItem key={index} label={label} link={link} links={links} />
    ))
    return (
        <>
            <Drawer
                opened={drawerOpened}
                onClose={closeDrawer}
                size="100%"
                padding="md"
                hiddenFrom="sm"
                zIndex={1000000}
                title="Menu"
            >
                <ScrollArea h="calc(100vh - 80px" mx="-md" type="always">
                    {items}
                    <Divider my="sm" />
                    <Group justify="center" grow pb="xl" px="md">
                        <Button variant="default">Log in</Button>
                        <Button color="#E00000">Sign up</Button>
                    </Group>
                </ScrollArea>
            </Drawer>
            <Burger opened={drawerOpened} onClick={toggleDrawer} aria-label="Toggle navigation" size="sm" hiddenFrom="sm" />
        </>
    )
}
