"use client"
import { ActionIcon, Anchor, Button, Checkbox, Divider, Group, Paper, PasswordInput, Text, TextInput } from "@mantine/core";
import classes from "./AuthForm.module.css";
import { useForm } from "@mantine/form";
import { useToggle } from "@mantine/hooks";
import { IconBrandGithub, IconBrandGoogle, IconBrandLinkedin } from "@tabler/icons-react";

export default function AuthForm() {
    const [type, toggle] = useToggle(['login', 'register', 'forgotpassword']);
    const form = useForm({
        initialValues: {
            email: '',
            first_name: '',
            last_name: '',
            password: '',
            terms: true,
        },

        validate: {
            email: (val) => (/^\S+@\S+$/.test(val) ? null : 'Invalid email'),
            first_name: (val) => (/^[a-zA-Z]+$/.test(val) ? null : 'Invalid first name'),
            last_name: (val) => (/^[a-zA-Z]+$/.test(val) ? null : 'Invalid last name'),
            password: (val) => (/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$/.test(val) ?
                'Password should include at least 6 characters' : null),
        },
    });
    const social = [
        {
            Icon: IconBrandGoogle,
            color: "#E94235",
            fill: "white",
            stroke: 0
        },
        {
            Icon: IconBrandLinkedin,
            color: "#006396",
            fill: "none",
            stroke: 2.5
        },
        {
            Icon: IconBrandGithub,
            color: "#202020",
            fill: "white",
            stroke: 0
        }
    ]
    const socialButtons = social.map(({ Icon, color, fill, stroke }, index) => (
        <ActionIcon key={index} size={40} radius="xl" color={color}>
            <Icon size={22} fill={fill} stroke={stroke} />
        </ActionIcon>
    ));
    return (
        <div className={classes.wrapper}>
            <Paper className={classes.form} radius={0} pt={30}>
                <form onSubmit={form.onSubmit(() => { })}>
                    <TextInput label="Email address" placeholder="hello@gmail.com" size="md" />
                    {
                        type === "register" && <>
                            <TextInput label="First Name" size="md" />
                            <TextInput label="Last Name" size="md" />
                        </>
                    }
                    {
                        (type === "register" || type === "login") &&
                        <PasswordInput label="Password" placeholder="Your password" mt="md" size="md" />
                    }
                    {
                        type === "login" && <Group mt="xl" justify="space-between">
                            <Checkbox label="Keep me logged in" size="md" />
                            <Anchor<'a'> href="#" fw={700} onClick={() => toggle('forgotpassword')} size="md">
                                Forgot password?
                            </Anchor>
                        </Group>
                    }
                    <Button fullWidth mt="xl" size="md" color="#E00000">
                        Continue
                    </Button>
                    <Text ta="center" mt="md">
                        {
                            type === "login" ? <>
                                Don&apos;t have an account?{' '}
                                <Anchor<'a'> href="#" fw={700} onClick={() => toggle('register')}>
                                    Register
                                </Anchor>
                            </> :
                                <>
                                    Already have an account? {' '}
                                    <Anchor<'a'> href="#" fw={700} onClick={() => toggle('login')}>
                                        Sign In
                                    </Anchor>
                                </>
                        }
                    </Text>
                </form>
                {
                    (type === "login" || type === "register") && <>
                        <Divider my="sm" label='Or sign in with' labelPosition="center" />
                        <Group justify="center">
                            {socialButtons}
                        </Group>
                    </>
                }
            </Paper>
        </div>
    )
}
