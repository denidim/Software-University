const {test,expect} = require("@playwright/test")
const appUrl = 'http://localhost:3000';

test('Verify All Books link is visible', async ({page})=>{
    await page.goto(appUrl);
    await page.waitForSelector('nav.navbar');
    const allBooksLink = await page.$('a[href="/catalog"]');
    const isElementVisible = await allBooksLink.isVisible();
    expect(isElementVisible).toBe(true);
});

test('Verify Login link is visible', async ({page})=>{
    await page.goto(appUrl);
    await page.waitForSelector('nav.navbar');
    const loginLink = await page.$('a[href="/login"]');
    const isElementVisible = await loginLink.isVisible();
    expect(isElementVisible).toBe(true);
});

test('Verify Register link is visible', async ({page})=>{
    await page.goto(appUrl);
    await page.waitForSelector('nav.navbar');
    const registerLink = await page.$('a[href="/register"]');
    const isElementVisible = await registerLink.isVisible();
    expect(isElementVisible).toBe(true);
});

test('Verify valid user can login', async ({page})=>{
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
    await page.$('a[href="/catalog"]');
    expect(page.url()).toBe('http://localhost:3000/catalog');
});

test('Verify submit form with empty input field give appropriate message', async ({page})=>{
    await page.goto('http://localhost:3000/login');
    await page.click('input[type="submit"]');
    page.on('dialog', async (dialog) => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are requred!');
        await dialog.accept();
    })
    await page.$('a[href="/login"]');
    expect(page.url()).toBe('http://localhost:3000/login');
});

test('Verify register form with empty input field give appropriate message', async ({page})=>{
    await page.goto('http://localhost:3000/register');
    await page.$('input[type="submit"]');
    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept()
    })
    //await page.$('a[href="/register"]');
    expect(page.url()).toBe('http://localhost:3000/register');
});

test('Add book with corect data', async({page})=>{
    await page.goto('http://localhost:3000/login');
    await page.fill('#email', 'peter@abv.bg');
    await page.fill('#password', '123456');
    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
    ]);
    await page.click('a[href="/create"]');
    await page.waitForSelector('#create-form');
    await page.fill('#title', 'Test Book');
    await page.fill('#description', 'this is Test Book descriptin');
    await page.fill('#image', 'https://www.freepik.com/free-photos-vectors/book-jpg');
    await page.selectOption('#type', 'Fiction')
    await page.click('#create-form input[type="submit"]');
    await page.waitForURL('http://localhost:3000/catalog')
    expect(page.url()).toBe('http://localhost:3000/catalog')
})

test('Login and verify all books are displayed', async ({ page }) => {
    await page.goto('http://localhost:3000/login');
  
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');
  
    await Promise.all([
      page.click('input[type="submit"]'), 
      page.waitForURL('http://localhost:3000/catalog') 
    ]);
  
    await page.waitForSelector('.dashboard');
  
    const bookElements = await page.$$('.other-books-list li');
  
    expect(bookElements.length).toBeGreaterThan(0);
  });