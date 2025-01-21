import { AuthForm } from "@/components/authenticationform";
import { Hero } from "@/components/hero";
import classes from "./page.module.css";
import { Container } from "@mantine/core";

export default function page() {
    return (
        <div className={classes.page}>
            <Container size="lg" className={classes.container}>
                <div className={classes.wrapperLeft}><Hero /></div>
                <div className={classes.wrapperRight}><AuthForm /></div>
            </Container>
        </div>
    )
}
