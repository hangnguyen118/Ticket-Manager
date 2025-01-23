import type { Metadata } from "next";
import "./globals.css";
import '@mantine/core/styles.css';
import '@mantine/carousel/styles.css';
import { createTheme, MantineProvider } from '@mantine/core';
import { Header } from "@/components/header";

export const metadata: Metadata = {
  title: "Create Ticker Manager App",
  description: "Generated by create next app",
};

const theme = createTheme({
  /** Put your mantine theme override here */
});

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <MantineProvider theme={theme}>
          <Header/>
          {children}
        </MantineProvider>
      </body>
    </html>
  );
}
