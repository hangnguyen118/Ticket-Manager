"use client"
import { ActionIcon, Badge, Center, Container, Grid, GridCol, Group, Image, Paper, Stack, Text } from "@mantine/core";
import classes from "./page.module.css";
import { IconArrowLeft, IconCalendarMonth } from "@tabler/icons-react";
import { useState } from "react";
import { daysShort } from "@/data/mockdatas";

const movies = [
    {

    },
    {

    },
]
export default function Page() {
    const [active, setActive] = useState(0);

    const days = daysShort.map((item, index) => (
        <Paper key={index} withBorder shadow="sm" w={40} onClick={() => setActive(index)}>
            <Center p={4}>
                <Text size="xs">{item.day}</Text>
            </Center>
            <Center className={active === index ? classes.content_highlight : classes.content}>
                <Text fw={500}>{item.date}</Text>
            </Center>
        </Paper>
    ))
    const movie_items = movies.map((item, index) => (
        <Paper key={index} withBorder shadow="md" p={10}>
            <Grid>
                <GridCol span={{ base: 4, sm: 3, md: 2 }}>
                    <Image src="https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/af88614f-fa76-475c-8cd9-7a491f9ba94b/dfezvoj-191d6fbb-6909-4e49-8670-ac0a657df9f3.jpg/v1/fill/w_1280,h_1785,q_75,strp/mufasa__the_lion_king__2024__fan_made_poster_by_hollywoodnewsindia_dfezvoj-fullview.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9MTc4NSIsInBhdGgiOiJcL2ZcL2FmODg2MTRmLWZhNzYtNDc1Yy04Y2Q5LTdhNDkxZjliYTk0YlwvZGZlenZvai0xOTFkNmZiYi02OTA5LTRlNDktODY3MC1hYzBhNjU3ZGY5ZjMuanBnIiwid2lkdGgiOiI8PTEyODAifV1dLCJhdWQiOlsidXJuOnNlcnZpY2U6aW1hZ2Uub3BlcmF0aW9ucyJdfQ.YrMXuofhBSw3GLemdvQHP18F-zx2iGb2qDrQxK9Kr_o" alt=""></Image>
                </GridCol>
                <GridCol span={{ base: 12, sm: 9, md: 10 }}>
                    <Text fw={700} size="xl">Mufasa: The Lion King</Text>
                    <Text c="dimmed">Hoạt hình, Hài hước, Phiêu lưu</Text>
                    <Text lineClamp={2}>Rafiki relays the legend of Mufasa to lion cub Kiara, daughter of Simba and Nala. Told in</Text>
                    <Text fw={500}>VI ENG Subs</Text>
                    <Group mt={10}>
                        <Badge variant="filled" color="red" radius="sm" pt={16} pb={16} size="lg">17:00 PM</Badge>
                        <Badge variant="filled" color="red" radius="sm" pt={16} pb={16} size="lg">17:30 PM</Badge>
                        <Badge variant="filled" color="red" radius="sm" pt={16} pb={16} size="lg">18:00 PM</Badge>
                        <Badge variant="filled" color="red" radius="sm" pt={16} pb={16} size="lg">19:00 PM</Badge>
                        <Badge variant="filled" color="red" radius="sm" pt={16} pb={16} size="lg">20:00 PM</Badge>
                        <Badge variant="filled" color="red" radius="sm" pt={16} pb={16} size="lg">21:00 PM</Badge>
                        <Badge variant="filled" color="red" radius="sm" pt={16} pb={16} size="lg">22:00 PM</Badge>
                    </Group>
                </GridCol>
            </Grid>
        </Paper>
    ))
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
                <Stack mt={20}>
                    {movie_items}
                </Stack>
            </Container>
        </div>
    )
}
