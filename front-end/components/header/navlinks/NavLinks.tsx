
import { Group } from "@mantine/core";
import classes from "./NavLinks.module.css";
import MenuItem from "../menuItem/MenuItem";
import { links } from "@/data/mockdatas";

export default function NavLinks({ ...rest }) {
    const items = links.map(({ label, link, links }, index) => (
        <MenuItem key={index} label={label} link={link} links={links} />
    ))
    return (
        <Group className={classes.navLinks} {...rest}>
            {items}
        </Group>
    )
}
