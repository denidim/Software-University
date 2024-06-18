const {test,expect} = require("@playwright/test")
const appUrl = 'http://localhost:3000';

test('Varify All Books link is visible', async ({page})=>{
    await page.goto(appUrl);
    await page.waitForSelector('nav.navbar');
    const allBooksLink = await page.$('a[href="/catalog"]');
    const isElementVisible = await allBooksLink.isVisible();
    expect(isElementVisible).toBe(true);
});

test('Varify Login link is visible', async ({page})=>{
    await page.goto(appUrl);
    //await page.waitForSelector('nav.navbar');
    const loginLink = await page.$('a[href="/login"]');
    const isElementVisible = await loginLink.isVisible();
    expect(isElementVisible).toBe(true);
});

test('Varify Register link is visible', async ({page})=>{
    await page.goto(appUrl);
    await page.waitForSelector('nav.navbar');
    const registerLink = await page.$('a[href="/register"]');
    const isElementVisible = await registerLink.isVisible();
    expect(isElementVisible).toBe(true);
});

test('Varify valid user can login', async ({page})=>{
    await page.goto(appUrl);
    await page.waitForSelector('nav.navbar');
    const loginLink = await page.$('a[href="/login"]');
    await loginLink.click();
    await page.fill('#email', 'peter@abv.bg');
    await page.fill('#password', '123456');
    const loginBtn = await page.$('fieldset > input.button.submit');
    await loginBtn.click();
    const logOutBtn= await page.$('#logoutBtn');
    const isVisible = await logOutBtn.isVisible();
    expect(isVisible).toBe(true);
});