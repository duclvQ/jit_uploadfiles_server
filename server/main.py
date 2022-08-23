from fastapi import FastAPI, Request, Depends, HTTPException
from fastapi.responses import HTMLResponse, FileResponse
from fastapi.staticfiles import StaticFiles
from fastapi.templating import Jinja2Templates
from typing import List
from fastapi import FastAPI, File, UploadFile, Form
from sqlalchemy.orm import Session
from fastapi import File, UploadFile
from typing import List
import shutil
#from . import crud, models, schemas
from .database import SessionLocal, engine
from .library.helpers import *

#from app.routers import twoforms, accordion ,unsplash


app = FastAPI()


templates = Jinja2Templates(directory="templates")
app.mount("/static", StaticFiles(directory="static"), name="static")


@app.get("/", response_class=HTMLResponse)
async def home(request: Request):
    data = openfile("home.md")
    return templates.TemplateResponse("home.html", {"request": request, "data": data})



@app.get("/disk_usage")
def disk_usage_statistics():
    stat = shutil.disk_usage('/home/levietduc/fast/fastapi-web-starter/')
    return stat.total, stat.used, stat.free
    
    
@app.post("/uploadfiles")
async def upload(file: UploadFile):
    
    try:
            contents = file.file.read()
            with open('trash/' + file.filename, 'wb') as f:
                f.write(contents)
    except Exception:
            return {"message": "There was an error uploading the file(s)"}
    finally:
            file.file.close()
    return f"Successfuly uploaded "





'''

@app.get("/page/{page_name}", response_class=HTMLResponse)
async def show_page(request: Request, page_name: str):
    
    return templates.TemplateResponse("page.html", {"request": request, "data": data})








models.Base.metadata.create_all(bind=engine)




# Dependency
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@app.post("/users/", response_model=schemas.User)
def create_user(user: schemas.UserCreate, db: Session = Depends(get_db)):
    db_user = crud.get_user_by_email(db, email=user.email)
    if db_ulser:
        raise HTTPException(status_code=400, detail="Email already registered")
    return crud.create_user(db=db, user=user)


@app.get("/users/", response_model=List[schemas.User])
def read_users(skip: int = 0, limit: int = 100, db: Session = Depends(get_db)):
    users = crud.get_users(db, skip=skip, limit=limit)
    return users


@app.get("/users/{user_id}", response_model=schemas.User)
def read_user(user_id: int, db: Session = Depends(get_db)):
    db_user = crud.get_user(db, user_id=user_id)
    if db_user is None:
        raise HTTPException(status_code=404, detail="User not found")
    return db_user


@app.post("/users/{user_id}/items/", response_model=schemas.Item)
def create_item_for_user(
    user_id: int, item: schemas.ItemCreate, db: Session = Depends(get_db)
):
    return crud.create_user_item(db=db, item=item, user_id=user_id)


@app.get("/items/", response_model=List[schemas.Item])
def read_items(skip: int = 0, limit: int = 100, db: Session = Depends(get_db)):
    items = crud.get_items(db, skip=skip, limit=limit)
    return items

'''