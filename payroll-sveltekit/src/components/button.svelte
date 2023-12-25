<script>
    export let children;
    export let className;
    export let outline;
    export let props;
</script>

<button
    class="{className} button {outline && 'outline'}"
    type="button"
    {...props}
>
    {children}
</button>

<style lang="css">
    :root {
        --blue: #012d6c;
        --blue-2: #08457e;
        --grey: #f2f2f2;
        --black: #4a4a4a;
        --light-red: #ffdfd1;
        --red: #ff4136;
        --light-green: #e0ffbe;
        --green: #0e940c;
        --light-gold: #c29c63;
        --gold: #8d7249;
        --dark-blue: #002149;
        --transparent-blue: rgba(1, 45, 108, 0.2);
    }

    .button {
        display: flex;
        justify-content: center;
        align-items: center;
        background: var(--gold);
        color: white;
        padding: 0 24px;
        height: 42px;
        font-family: inherit;
        font-size: 18px;
        font-family: inherit;
        font-weight: 700;
        text-align: center;
        vertical-align: top;
        cursor: pointer;
        border: 0;
        border-radius: 2px;
    }
    .button:active,
    .button:focus {
        outline: 0;
    }
    .button a {
        color: inherit;
        text-decoration: none !important;
    }
    .button a:visited {
        color: inherit;
    }

    .outline {
        color: var(--gold);
        border: 1px solid var(--gold);
        background: white;
    }

    @media only screen and (max-width: 768px) {
        .button {
            height: 36px;
        }
    }
</style>
