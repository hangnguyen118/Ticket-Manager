"use client"
import { ActionIcon, Avatar, Box, Card, Container, Group, Stack, Text } from "@mantine/core";
import classes from "./page.module.css";
import { IconArrowLeft, IconStar } from "@tabler/icons-react";
import { useState } from "react";
import { cinemas } from "@/data/mockdatas";

export default function Page() {
    const [active, setActive] = useState(0);

    const items = cinemas.map((item, index) => (
        <Avatar
            key={index}
            size="md"
            component="button"
            onClick={() => setActive(index)}
            className={index === active ? classes.highlight_item : classes.cinema_item}
            color="initials"
            radius="sm"
            src={item.imageUrl}
        />
    ))

    const cinemas_item = cinemas.map((item, index) => (
        <Card key={index} withBorder className={classes.card} padding="xs" mb={10}>
            <Group justify="space-between" mb={4}>
                <Group>
                    <Avatar size="md" className={classes.cinema_item} color="red" radius="sm" src={"https://th.bing.com/th/id/OIP.Sxe1CkTZ1F7wYEnUWudgQgHaFj?pid=ImgDet&w=474&h=355&rs=1"} />
                    <Box>
                        <Text fw={500}>Sport Cinema</Text>
                        <Text c="dimmed" size="sm">Sport Cinema</Text>
                    </Box>
                </Group>
                <ActionIcon variant="outline" color="yellow" aria-label="Settings">
                    <IconStar style={{ width: '70%', height: '70%' }} stroke={1.5} />
                </ActionIcon>
            </Group>
            <Text c="dimmed" size="xs" lineClamp={1}>Địa chỉ: 32F6 DN6, Đông Hưng Thuận, Quận 12, Hồ Chí Minh, Việt Nam Hồ Chí Minh, Việt Nam Hồ Chí Minh, Việt Nam</Text>
        </Card>
    ));

    return (
        <div className={classes.page}>
            <Container size="lg">
                <Group mb={10}>
                    <ActionIcon component="a" href="/" radius="lg" variant="light">
                        <IconArrowLeft />
                    </ActionIcon>
                    <Text fw={700}>Chọn theo rạp</Text>
                </Group>
                <Group mt={10} mb={10}>
                    {items}
                </Group>
                <Text fw={700}>Rạp đề xuất</Text>
                <Stack>
                    {cinemas_item}
                </Stack>
            </Container>
        </div>
    )
}
