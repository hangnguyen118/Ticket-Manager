'use client'
import { Box, Center, Collapse, UnstyledButton } from '@mantine/core';
import { IconChevronDown } from '@tabler/icons-react';
import { useRouter } from 'next/navigation';
import classes from "./NavMobile.module.css";
import { Menu } from '@/data/types';
import { useDisclosure } from '@mantine/hooks';

export default function NavMobileMenu({item, key, link}: {item:Menu, key:number, link:string}) {
    const router = useRouter();
    const [linksOpened, { toggle: toggleLinks }] = useDisclosure(false);
    const menuItems = item.links?.map(({ link, label }, index) => (
        <UnstyledButton
            key={index}
            className={classes.link}
            onClick={() => router.push(link)}
        >
            <Box component="span" ml={20}>
                
            </Box>
            {label}
        </UnstyledButton>
    ));
    if (menuItems) {
        return (
            <div key={item.label}>
                <UnstyledButton
                    className={classes.link}
                    onClick={toggleLinks}
                >
                    <Center inline>
                        <Box component="span" mr={5}>
                            {item.label}
                        </Box>
                        <IconChevronDown size={16} />
                    </Center>
                </UnstyledButton>
                <Collapse in={linksOpened}>{menuItems}</Collapse>
            </div>
        )
    }
    return (
        <UnstyledButton
            key={key}
            className={classes.link}
            onClick={() => router.push(link)}
        >
            {item.label}
        </UnstyledButton>
    );
}
