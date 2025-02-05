
"use client"
import { Badge, Container, SimpleGrid } from "@mantine/core";
import classes from "./page.module.css";
import { seats } from "@/data/mockdatas";
import { useListState } from "@mantine/hooks";

export default function Page() {
    const [values, handlers] = useListState<string>([]);

    const items = Object.keys(seats).map((row, index) => (
        <SimpleGrid cols={16} key={index} spacing={4} verticalSpacing={4} mb={16} miw='36em'>
            {
                seats[row].map((item) => (
                    <Badge key={item.id} variant={values.includes(`${row}${item.number}`) ? "filled" : "light"} onClick={() => handlers.append(`${row}${item.number}`)} radius="sm" className={classes.badge_root} fw={500} color="indigo">{`${item.row}${item.number}`}</Badge>
                ))
            }
        </SimpleGrid>
    ));
    return (
        <div className={classes.page}>
            <Container size="lg">
                {items}
            </Container>
        </div>
    )
}
