import classes from "./page.module.css";
import { Container, Title } from "@mantine/core";
import { Carousels } from "@/components/carousels";

export default function Home() {
  return (
    <div className={classes.page}>
      <main>
        <Container size="lg" className={classes.container}>
          <div>
            <Title order={4} className={`${classes.dark} ${classes.light}`}>Phim nổi bật</Title>
            <Carousels />
          </div>
          <div>
            <Title order={4}>Phim đang chiếu</Title>
            <Carousels />
          </div>
          <div>
            <Title order={4}>Lượt xem cao nhất</Title>
            <Carousels />
          </div>
        </Container>
      </main>
    </div>
  );
}
