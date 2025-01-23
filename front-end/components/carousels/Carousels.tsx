"use client"
import { movies } from "@/data/mockdatas"
import { Card, CardSection, Image, Text, useMantineTheme } from "@mantine/core"
import classes from "./Carousels.module.css";
import { Carousel, CarouselSlide } from "@mantine/carousel";
import { useMediaQuery } from "@mantine/hooks";


export default function Carousels() {
    const theme = useMantineTheme()
    const mobile = useMediaQuery(`(max-width: ${theme.breakpoints.sm})`);
    const items = movies.map(({ title, posterUrl, genre }, index) => (
        <CarouselSlide key={index}>
            <Card className={classes.card} key={index} shadow="sm" padding="md">
                <CardSection>
                    <Image src={posterUrl} alt={title} fit="cover" radius="md" h={mobile ? 200 : 300}></Image>
                </CardSection>
                <Text fz="sm" fw={700} className={classes.title} lineClamp={1}>{title}</Text>
                <Text fz="xs" c="dimmed" lineClamp={1}>{genre.join(", ")}</Text>
            </Card>
        </CarouselSlide>
    ))
    return (
        <div className={classes.wrapper}>
            <Carousel
                slideSize={{ base: "50%", xs: "33.33%", sm: "33.33%", md: "23.33%" }}
                slideGap="md"
                withControls={mobile ? false : true}
                loop={true}
            >
                {items}
            </Carousel>
        </div >
    )
}
