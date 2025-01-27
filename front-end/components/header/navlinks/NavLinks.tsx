
import { Group } from "@mantine/core";
import classes from "./NavLinks.module.css";
import MenuItem from "../menuItem/MenuItem";
import { links } from "@/data/mockdatas";
import { BaseProps } from "@/data/types";

export default function NavLinks({visibleFrom}:BaseProps) {
    const items = links.map(({ label, link, links }, index) => (
            <MenuItem key={index} label={label} link={link} links={links} />
        ))
    return (
        <Group visibleFrom={visibleFrom} className={classes.navLinks}>
            {items}
        </Group>
    )
}
