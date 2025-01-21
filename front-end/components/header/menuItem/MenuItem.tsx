import Link from "next/link";
import classes from "./MenuItem.module.css";
import { Box, Center, Collapse, UnstyledButton } from "@mantine/core";
import { Menu } from "@/data/types";
import { useDisclosure } from "@mantine/hooks";
import { IconChevronDown } from "@tabler/icons-react";

export default function MenuItem({ label, link, links }: Menu) {
    const [linksOpened, { toggle: toggleLinks }] = useDisclosure(false);
    return (
        <div className={classes.wrapper}>
            {links ? <>
                <div className={classes.menu}>
                    <UnstyledButton className={classes.link} onClick={toggleLinks}>
                        <Center inline>
                            <Box component="span" mr={5}>
                                {label}
                            </Box>
                            <IconChevronDown size={16} className={`${linksOpened ? classes.iconRotated : classes.icon}`} />
                        </Center>
                    </UnstyledButton>
                    <Collapse in={linksOpened} className={classes.collapse}>
                        {links.map(({ label, link, links }, index) => (<MenuItem key={index} label={label} link={link} links={links} />))}
                    </Collapse>
                </div>
            </>
                :
                <Link href={link} className={classes.link}>{label}</Link>}
        </div>
    )
}
