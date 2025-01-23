import classes from "./MovieCard.module.css";
import { Movie } from "@/data/types";
import { Grid, GridCol, Text } from "@mantine/core";

export default function MovieCard({ title, description, genre, duration, release_day, posterUrl }: Movie) {
  return (
    <div className={classes.wrapper}>
      <Grid>
        <GridCol span={4} className={classes.wrapper_left}>Image</GridCol>
        <GridCol span={8} className={classes.wrapper_right}> <Text>{title}</Text></GridCol>
      </Grid>
    </div>
  )
}
