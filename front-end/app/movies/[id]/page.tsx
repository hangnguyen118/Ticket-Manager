"use client"
import { Badge, Button, Container, Image, Text, useMantineTheme } from "@mantine/core";
import classes from "./page.module.css";
import { IconArrowLeft, IconArrowRight, IconPlayerPlay, IconTicket } from "@tabler/icons-react";
import { useMediaQuery } from "@mantine/hooks";
import { useParams, useRouter } from "next/navigation";

const movie = {
    title: "Nụ Hôn Bạc Tỷ",
    release_day: "18/02/2025",
    description:
        "The story revolves around Vân, a bread seller who accidentally encounters two young men in a minor accident. What happens when love at first sight strikes all three of them simultaneously? Between a mature, manly guy and a slightly rebellious, cool one, who will win the ",
    genre: ["Hài Hước", "Chính kịch", "Lãng mạng"],
    posterUrl:
        "https://cinema.momocdn.net/img/31337174866614229-nhbt.jpg?size=M",
    duration: 180,
    rating: 5.0,
    age_rating: 18,
}

export default function Page() {
    const theme = useMantineTheme()
    const mobile = useMediaQuery(`(max-width: ${theme.breakpoints.sm})`);
    const router = useRouter();
    const { id } = useParams();
    return (
        <div className={classes.page}>
            <Container size="lg">
            <Button onClick={() => router.push('/')} fullWidth justify="left" mb={10} variant="transparent" leftSection={<IconArrowLeft size={14} />}>Back to Home</Button>
                <div className={classes.movie_hero}>
                    <Badge className={classes.age_rating} color="rgba(255, 61, 61, 1)">{movie.age_rating}+</Badge>
                    <Image src={movie.posterUrl} fit="contain" height={mobile ? 200 : 350} alt={movie.title}></Image>
                    <div className={classes.content_left}>
                        <Text fw={700} size="16px">{movie.title}</Text>
                        <div>
                            <Text fw={500} inherit>Ngày phát hành: </Text>
                            <Text>{movie.release_day}</Text>
                        </div>
                        <div>
                            <Text fw={500} inherit>Thời lượng: </Text>
                            <Text>{movie.duration}p</Text>
                        </div>
                        <Button variant="outline" rightSection={<IconPlayerPlay size={20} />} mb={8} w={140}>Xem trailer</Button>
                    </div>
                </div>
                <div>
                    <Text fw={500} inherit>Rating: {movie.rating}</Text>
                    <Text c="dimmed">Thể loại: {movie.genre.join(", ")}</Text>
                    <Text>{movie.description}</Text>
                </div>
                <div>
                    <Text fw={700} size="lg">Rạp đang chiếu</Text>
                    <Button rightSection={<IconTicket size={20} />} w="100%">Đặt vé</Button>
                </div>
            </Container>
        </div>
    )
}
