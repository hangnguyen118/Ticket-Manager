'use client'
import { Center, Group, Menu, MenuDropdown, MenuTarget } from "@mantine/core";
import { links } from "@/data/mockdatas";
import { IconChevronDown } from "@tabler/icons-react";
import classes from "./NavLinks.module.css";
import { useRouter } from "next/navigation";
import Link from "next/link";

export default function NavLinks() {
    const router = useRouter();
    const items = links.map((item, index) => {
        const menuItems = item.links?.map(({ link, label }, index) => (
            <Menu.Item key={index} onClick={() => router.push(link)}>
                {label}
            </Menu.Item>
        ));
        if (menuItems) {
            return (
                <Menu key={item.label} trigger="hover" transitionProps={{ exitDuration: 0 }} withinPortal>
                    <MenuTarget>
                        <a
                            href={item.link}
                            className={classes.link}
                            onClick={(event) => event.preventDefault()}
                        >
                            <Center>
                                <span className={classes.linkLabel}>{item.label}</span>
                                <IconChevronDown size={14} stroke={1.5} />
                            </Center>
                        </a>
                    </MenuTarget>
                    <MenuDropdown>
                        <Menu.Label>Application</Menu.Label>
                        {menuItems}
                    </MenuDropdown>
                </Menu>
            )
        }
        return (
            <Link
                key={index}
                href={item.link}
                className={classes.link}
                onClick={() => router.push(item.link)}
            >
                {item.label}
            </Link>
        );
    });
    return (
        <Group>
            {items}
        </Group>
    )
}
