'use client'
import { Button, Container, Flex, Group, Text } from "@mantine/core";
import classes from "./page.module.css";
import { IconArrowLeft } from "@tabler/icons-react";
import { MovieCard } from "@/components/moviecard";
import { movies } from "@/data/mockdatas";
import { useRouter } from "next/navigation";

export default function Page() {
    const items = movies.map((item, index) => (
        <MovieCard key={index} {...item} direction={{ base: "row", sm: "column" }}></MovieCard>
    ))
    const router = useRouter();
    return (
        <div className={classes.page}>
            <Container size="lg">
                <Group mb={10}>
                    <Button onClick={() => router.push('/')} fullWidth justify="left" mb={10} variant="transparent" leftSection={<IconArrowLeft size={14} />}>Back to Home</Button>
                    <Text fw={700}>Phim đang chiếu</Text>
                </Group>
                <Flex direction={{ base: "column", sm: "row" }} wrap="wrap" gap={10} justify="start">
                    {items}
                </Flex>
            </Container>
        </div>
    )
}
