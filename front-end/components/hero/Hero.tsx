import { List, ListItem, Text, ThemeIcon, Title } from "@mantine/core";
import classes from "./Hero.module.css";
import { IconCheck } from "@tabler/icons-react";

export default function Hero() {
    return (
        <div className={classes.container}>
            <div className={classes.inner}>
                <div className={classes.content}>
                    <Title order={2}>Get 10 days free! Start now.</Title>
                    <Text c="dimmed" mt="md" lineClamp={1}>
                        No credit card required.
                    </Text>
                    <Title order={2}>Create an account to start your free trial</Title>
                    <List
                        mt={30}
                        spacing="sm"
                        size="sm"
                        visibleFrom="sm"
                        icon={
                            <ThemeIcon size={20} radius="xl">
                                <IconCheck size={12} stroke={1.5} />
                            </ThemeIcon>
                        }
                    >
                        <ListItem>
                            <b>TypeScript based</b> – build type safe applications, all components and hooks
                            export types
                        </ListItem>
                        <ListItem>
                            <b>Free and open source</b> – all packages have MIT license, you can use Mantine in
                            any project
                        </ListItem>
                        <ListItem>
                            <b>No annoying focus ring</b> – focus ring will appear only when user navigates with
                            keyboard
                        </ListItem>
                    </List>
                </div>
            </div>
        </div>
    )
}
