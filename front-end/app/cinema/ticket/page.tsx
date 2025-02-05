"use client"
import { ActionIcon, Avatar, Badge, Box, Card, Center, Container, Group, Paper, Stack, Text } from "@mantine/core";
import classes from "./page.module.css";
import { useState } from "react";
import { cinemas, daysShort } from "@/data/mockdatas";
import { IconArrowLeft, IconCalendarMonth, IconStar } from "@tabler/icons-react";

export default function Page() {
    const [active, setActive] = useState(0);
    const [cinemaActive, setCinemaActive] = useState(0);

    const days = daysShort.map((item, index) => (
        <Paper key={index} withBorder shadow="sm" w={40} onClick={() => setActive(index)}>
            <Center p={4}>
                <Text size="xs">{item.day}</Text>
            </Center>
            <Center className={active === index ? classes.content_highlight : classes.content}>
                <Text fw={500}>{item.date}</Text>
            </Center>
        </Paper>
    ));
    const items = cinemas.map((item, index) => (
        <Avatar
            key={index}
            size="md"
            component="button"
            onClick={() => setCinemaActive(index)}
            className={index === cinemaActive ? classes.highlight_item : classes.cinema_item}
            color="initials"
            radius="sm"
            src={item.imageUrl}
        />
    ));
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
            <Text>2D VN ENG SUB</Text>
            <Group>
                <Badge variant="outline" radius="sm" p={14}> 18:00~21:00</Badge>
                <Badge variant="outline" radius="sm" p={14}> 18:00~21:00</Badge>
                <Badge variant="outline" radius="sm" p={14}> 18:00~21:00</Badge>
                <Badge variant="outline" radius="sm" p={14}> 18:00~21:00</Badge>
                <Badge variant="outline" radius="sm" p={14}> 18:00~21:00</Badge>
            </Group>
        </Card>
    ));
    return (
        <div className={classes.page}>
            <Container size="lg">
                <Group mb={10}>
                    <ActionIcon component="a" href="/" radius="lg" variant="light">
                        <IconArrowLeft />
                    </ActionIcon>
                    <Text fw={700}>Beta Quang Trung</Text>
                </Group>
                <Group>
                    {days}
                    <ActionIcon variant="filled" aria-label="Settings">
                        <IconCalendarMonth style={{ width: '100%', height: '70%' }} stroke={1.5} />
                    </ActionIcon>
                </Group>
                <Group mt={20}>
                    <Badge variant="filled" color="red">Tất cả</Badge>
                    <Badge variant="light" color="red"> 18:00~21:00</Badge>
                    <Badge variant="light" color="red">21:00~23:00</Badge>
                </Group>
                <Group mt={20} mb={20}>
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
