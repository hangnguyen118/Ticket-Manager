import { ActionIcon, Container, Divider, Group, Text } from "@mantine/core";
import classes from "./page.module.css";
import { IconArrowLeft } from "@tabler/icons-react";
import { MovieCard } from "@/components/moviecard";
import { movies } from "@/data/mockdatas";

export default function page() {
    const items = movies.map((item, index) => (
        <div key={index}>
            <MovieCard {...item} />
            <Divider my="sm"></Divider>
        </div>
    ))
    return (
        <div className={classes.page}>
            <Container size="lg">
                <Group mb={10}>
                    <ActionIcon component="a" href="/" radius="lg" variant="light"><IconArrowLeft /></ActionIcon>
                    <Text fw={700}>Phim đang chiếu</Text>
                </Group>
                {items}
            </Container>
        </div>
    )
}
