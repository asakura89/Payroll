<script lang="ts">
    import type { PageData } from './$types';
    
    console.log("home/login/+page.svelte");
    export let data: PageData;
</script>

<svelte:head>
    <title>{data.title}</title>
</svelte:head>

<h2>Login</h2>

<form method="post" enctype="multipart/form-data" class="form-horizontal">
    <div class="input-group">
        <label for="username-textbox" class="control-label">Username</label>
        <input type="text" id="username-textbox" class="form-control">
    </div>
    <div class="input-group">
        <label for="password-textbox" class="control-label">Password</label>
        <input type="password" id="password-textbox" class="form-control">
    </div>
    <div class="input-group">
        <button type="submit" class="btn btn-primary" style="margin-top: 10px;">Sign in</button>
    </div>
</form>