import classes from "./MovieCard.module.css";
import { Movie } from "@/data/types";
import { Badge, Box, Card, Flex, Group, Image, Text } from "@mantine/core";
import { IconCalendarMonth, IconClockHour3 } from "@tabler/icons-react";

interface MovieCardProps extends Movie {
  [key: string]: unknown;
}

export default function MovieCard({ title, rating, age_rating, genre, duration, release_day, ...rest }: MovieCardProps) {
  return (
    <Card className={classes.card} shadow="sm" padding={0}>
      <Flex {...rest}>
        <Box className={classes.card_section}>
          <Image src="https://cinema.momocdn.net/img/55117941458947931-botubaothu.jpg?size=M" alt={title} fit="cover" h={{base: 200, sm:300}} radius="md" />
          <Badge className={classes.badge} color="rgba(255, 61, 61, 1)">{age_rating}+</Badge>
        </Box>
        <Box p={10}>
          <Text>{rating}</Text>
          <Text fw={700} lineClamp={1}>{title}</Text>
          <Text lineClamp={1} c="dimmed">{genre.join(", ")}</Text>
          <Group>
            <IconClockHour3 />
            <Text c="dimmed">{duration}</Text>
          </Group>
          <Text lineClamp={1} c="dimmed" inline={true}>
            <IconCalendarMonth size={22} />
            {release_day}
          </Text>
        </Box>
      </Flex>
    </Card>
  )
}
